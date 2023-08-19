using AutoMapper;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Models;
using WebExercicios.Service.Interface;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Service;
public class CountryService : ICountryService
{
    private readonly ExercicioContext _context;
    private readonly IMapper _mapper;
    public string erro;

    public CountryService(ExercicioContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public bool Add(CountryInput countryInput)
    {
        if (countryInput.Country_id == 0)
        {
            try
            {
                Countrys countrys = _mapper.Map<Countrys>(countryInput);
                _context.Country.Add(countrys);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                return false;
            }
        }
        else
        {
            try
            {
                Countrys countrys = _mapper.Map<Countrys>(countryInput);
                _context.Country.Update(countrys);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                return false;
            }
        }
    }
    public List<CountryOutput> GetLista()
    {
        List<Countrys> listDb = _context.Country.AsEnumerable().ToList();
        List<CountryOutput> list = _mapper.Map<List<CountryOutput>>(listDb);
        return list;
    }
    public bool Delete(int id)
    {
        try
        {
            Countrys countrys = _context.Country.Where(country => country.Country_id == id).FirstOrDefault();
            _context.Country.Remove(countrys);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            erro = ex.Message;
            return false;
        }
    }
}

