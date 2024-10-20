using System;
using System.Collections.Generic;
using System.Linq;

public class SpaceRepository
{
    private readonly AppDbContext _context;

    public SpaceRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Space> GetAll()
    {
        return _context.Spaces.ToList();
    }

    public Space GetById(Guid id)
    {
        return _context.Spaces.Find(id); // Remove the second return statement
    }

    public void Add(Space space)
    {
        _context.Spaces.Add(space);
        _context.SaveChanges();
    }

    public void Update(Space space)
    {
        _context.Spaces.Update(space);
        _context.SaveChanges();
    }

    public void Remove(Space space)
    {
        _context.Spaces.Remove(space);
        _context.SaveChanges();
    }
}