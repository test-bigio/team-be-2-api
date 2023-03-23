using BigioHrServices.Db;
using BigioHrServices.Db.Entities;
using BigioHrServices.Model.Datatable;
using BigioHrServices.Model.Position;
using Microsoft.EntityFrameworkCore;

namespace BigioHrServices.Services;

public interface IPositionService
{
    public Pageable<PositionResponse> GetList(PositionSearchRequest request);
    public Position? GetPositionById(long id);
    public void PositionAdd(PositionAddRequest request);
    public void PositionUpdate(PositionUpdateRequest request);
    public void PositionDeactive(long? id);
}

public class PositionServices : IPositionService
{
    private readonly ApplicationDbContext _dbContext;

    public PositionServices(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Pageable<PositionResponse> GetList(PositionSearchRequest request)
    {
        var query = _dbContext.Position
            .AsNoTracking()
            .AsQueryable();
        
        if(!string.IsNullOrEmpty(request.Search))
        {
            query = query.Where(p =>
                p.Code.ToLower() == request.Search.ToLower() ||
                p.Name.ToLower() == request.Search.ToLower());
        }

        var data = query
            .Select(position => new PositionResponse
            {
                Id = position.Id,
                Code = position.Code,
                Level = position.Level,
                Name = position.Name,
                IsActive = position.IsActive,
                CreatedBy = position.CreatedBy,
                CreatedDate = position.CreatedDate,
                UpdatedBy = position.UpdatedBy,
                UpdatedDate = position.UpdatedDate,
            }).ToList();

        return new Pageable<PositionResponse>(data, request.Page, request.PageSize);
    }

    public Position? GetPositionById(long id)
    {
        var positionResponse = _dbContext.Position.Find(id);
        if(positionResponse == null )  throw new Exception("Position not found!");
        return _dbContext.Position.Find(id);
    }

    public void PositionAdd(PositionAddRequest request)
    {
        var data = _dbContext.Position
            .Where(p => p.Code.ToLower() == request.Code)
            .AsNoTracking()
            .FirstOrDefault();
        if (data != null) throw new Exception("Code already exists!");

        try
        {
            _dbContext.Position.Add(new Position
            {
                Code = request.Code,
                Level = request.Level,
                Name = request.Name,
                IsActive = request.IsActive
            });

            _dbContext.SaveChanges();
        }   
        catch (Exception ex)
        {
            throw new Exception("Failed to add data");
        }
    }
    
    public void PositionUpdate(PositionUpdateRequest request)
    {
        var data = _dbContext.Position.Find(request.Id);
        if (data == null) throw new Exception("ID not found!");
        var codeExist = _dbContext.Position
            .Where(p => p.Code.ToLower() == request.Code)
            .Where(p => p.Id != request.Id)
            .AsNoTracking()
            .FirstOrDefault();
        if (codeExist != null) throw new Exception("Code already exists!");

        try
        {
            data.Id = request.Id;
            data.Code = request.Code;
            data.Level = request.Level;
            data.Name = request.Name;
            data.IsActive = request.IsActive;
            data.UpdatedBy = null;
            data.UpdatedDate = DateTime.UtcNow;
                   
            _dbContext.Update(data);
            _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            throw new Exception("Failed to update data");
        }
    }

    public void PositionDeactive(long? id)
    {
        var data = _dbContext.Position.Find(id);
        if(data == null )  throw new Exception("Position not found!");
        
        //validasi tidak digunakan pegawai
        var employee = _dbContext.Employees
            .Where(p => p.Position == data)
            .AsNoTracking()
            .FirstOrDefault();
        if(employee != null )  throw new Exception("Position used by employee!");

        try
        {
            data.IsActive = false;
            data.UpdatedBy = null;
            data.UpdatedDate = DateTime.UtcNow;
            
            _dbContext.Update(data);
            _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            throw new Exception("Failed to deactivate position");
        }
    }
}