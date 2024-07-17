using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TrackController : BaseApiController
{
    private readonly IGenericRepository<Track> _trackRepo;
    private readonly IGenericRepository<Genre> _genresRepo;
    private readonly IGenericRepository<Medium> _mediumRepo;
    private readonly IGenericRepository<Producer> _producerRepo;
    private readonly IGenericRepository<Label> _labelRepo;
    
    private readonly IMapper _mapper;
    

    public TrackController(IGenericRepository<Track> tracksRepo,IGenericRepository<Genre> genresRepo, 
        IGenericRepository<Medium> mediumRepo, IGenericRepository<Producer> producerRepo, IGenericRepository<Label> labelRepo, 
        IMapper mapper)
    {
        _trackRepo = tracksRepo;
        _genresRepo = genresRepo;
        _mediumRepo = mediumRepo;
        _producerRepo = producerRepo;
        _labelRepo = labelRepo;
        
        _mapper = mapper;
        
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TrackToReturnDto>> GetTrack(int id)
    {
        var spec = new TracksSpecification(id);
        var track = await _trackRepo.GetEntityWithSpec(spec);
        return _mapper.Map<Track, TrackToReturnDto>(track);
        //return track;

    }

    [HttpGet("id/{id}")]
    public ActionResult<Track> GetTrackById(int id)
    {
        var track = _trackRepo.GetById(id);
        return track;
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<TrackToReturnDto>>> GetTracks([FromQuery]TrackSpecParams trackParams)
    {
        var spec = new TracksSpecification(trackParams);
        var countSpec = new TrackWithFiltersCountSpecification(trackParams);
        var totalItems = await _trackRepo.CountAsync(countSpec);
        var tracks = await _trackRepo.ListAsync(spec);
        var data = _mapper.Map<IReadOnlyList<Track>, IReadOnlyList<TrackToReturnDto>>(tracks);
        //return Ok(await _trackRepo.ListAsync(spec));
        
        //return Ok(_mapper.Map<IReadOnlyList<Track>, IReadOnlyList<TrackToReturnDto>>(tracks));
        return Ok(new Pagination<TrackToReturnDto>(trackParams.PageIndex, trackParams.PageSize, totalItems, data));
    }
    
    //[Authorize(Roles = "Admin")]
    [HttpGet("genre")]
    public async Task<ActionResult<IReadOnlyList<Genre>>> GetGenres()
    {
        return Ok(await _genresRepo.ListAllAsync());
    }
    
    //[Authorize(Roles = "Admin")]
    [HttpGet("medium")]
    public async Task<ActionResult<IReadOnlyList<Medium>>> GetMediums()
    {
        return Ok(await _mediumRepo.ListAllAsync());
    }
    
    

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<Track>> CreateTrack([FromBody]TrackCreationDto trackDto)
    {
        try
        {
            if (trackDto != null)
            {


                var track = new Track
                {
                    TrackName = trackDto.TrackName,
                    Price = trackDto.Price,
                    Duration = trackDto.Duration,
                    PublishDate = trackDto.PublishDate,
                    PictureUrl = trackDto.PictureUrl,
                    Quantity = trackDto.Quantity,
                    GenreId = trackDto.GenreId,
                    Genre = _genresRepo.GetByIdAsync(trackDto.GenreId).Result,
                    MediumId = trackDto.MediumId,
                    Medium = _mediumRepo.GetByIdAsync(trackDto.MediumId).Result,
                    ProducerId = trackDto.ProducerId,
                    Producer = _producerRepo.GetByIdAsync(trackDto.ProducerId).Result,
                    LabelId = trackDto.LabelId,
                    Label = _labelRepo.GetByIdAsync(trackDto.LabelId).Result,

                };

                _trackRepo.CreateAsync(track);
                return Ok(track);
            }

            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /*
    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<ActionResult<Track>> UpdateTrack([FromBody] TrackCreationDto trackDto)
    {
        try
        {
            var track = _trackRepo.GetByIdAsync(trackDto.Id);
            if (track != null)
            {

                track.Result.Id = trackDto.Id;
                track.Result.TrackName = trackDto.TrackName;
                track.Result.Price = trackDto.Price;
                track.Result.Duration = trackDto.Duration;
                track.Result.PublishDate = trackDto.PublishDate;
                track.Result.PictureUrl = trackDto.PictureUrl;
                track.Result.Quantity = trackDto.Quantity;
                track.Result.GenreId = trackDto.GenreId;
                track.Result.Genre = _genresRepo.GetByIdAsync(trackDto.GenreId).Result;
                track.Result.MediumId = trackDto.MediumId;
                track.Result.Medium = _mediumRepo.GetByIdAsync(trackDto.MediumId).Result;
                track.Result.ProducerId = trackDto.ProducerId;
                track.Result.Producer = _producerRepo.GetByIdAsync(trackDto.ProducerId).Result;
                track.Result.LabelId = trackDto.LabelId;
                track.Result.Label = _labelRepo.GetByIdAsync(trackDto.LabelId).Result;

                _trackRepo.UpdateAsync(track.Result);

                return Ok(track.Result);

                //_trackRepo.CreateAsync(track);
                //return Ok(track);
            }

            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    */
    
    
    
    [Authorize(Roles = "Admin")]
    [HttpPost("genre")]
    public async Task<ActionResult<Genre>> CreateGenre([FromBody]Genre genre)
    {
        try
        {
            if (genre != null)
            { 
                _genresRepo.CreateAsync(genre);
                return Ok(genre);
            }

            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    
    [Authorize(Roles = "Admin")]
    [HttpPost("medium")]
    public async Task<ActionResult<Genre>> CreateMedium([FromBody]Medium medium)
    {
        try
        {
            if (medium != null)
            { 
                _mediumRepo.CreateAsync(medium);
                return Ok(medium);
            }

            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new ErrorResponse
            {
                ErrorMessage = new ErrorMessage
                {
                    Message = e.Message
                }
            });
        }
    }
    
    [HttpGet("medium/{id}")]
    public async Task<ActionResult<Label>> GetMedium(int id)
    {
        return Ok(await _mediumRepo.GetByIdAsync(id));
    } 
    
    
    [HttpGet("label/{id}")]
    public async Task<ActionResult<Label>> GetLabel(int id)
    {
        return Ok(await _labelRepo.GetByIdAsync(id));
    } 
    
    [Authorize(Roles = "Admin")]
    [HttpPost("label")]
    public async Task<ActionResult<Label>> CreateLabel([FromBody]Label label)
    {
        try
        {
            if (label != null)
            { 
                _labelRepo.CreateAsync(label);
                return Ok(label);
            }

            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("producer/{id}")]
    public async Task<ActionResult<Producer>> GetProducer(int id)
    {
        return Ok(await _producerRepo.GetByIdAsync(id));
    } 
    
    [HttpGet("producer")]
    public async Task<ActionResult<IReadOnlyList<Producer>>> GetProducers()
    {
        return Ok(await _producerRepo.ListAllAsync());
    } 
    
    [HttpGet("label")]
    public async Task<ActionResult<IReadOnlyList<Label>>> GetLabels()
    {
        return Ok(await _labelRepo.ListAllAsync());
    } 

    [HttpGet("trackall")]
    public async Task<ActionResult<IReadOnlyList<TrackToReturnDto>>> GetTracksAll()
    {
        var track = await _trackRepo.ListAllAsync();
        return Ok(_mapper.Map<IReadOnlyList<Track>,IReadOnlyList<TrackToReturnDto>>(track));
       
    } 
    
    [Authorize(Roles = "Admin")]
    [HttpPost("producer")]
    public async Task<ActionResult<Producer>> CreateProducer([FromBody]Producer producer)
    {
        try
        {
            if (producer != null)
            { 
                _producerRepo.CreateAsync(producer);
                return Ok(producer);
            }

            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("genre/{Id}")]
    public IActionResult DeleteGenre(int id)
    {
        try
        {
            if (id != null)
            {
                _genresRepo.DeleteAsync(id);
            
                return Ok();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
            throw;
        }

        return NoContent();
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("medium/{Id}")]
    public IActionResult DeleteMedium(int id)
    {
        try
        {
            if (id != null)
            {
                _mediumRepo.DeleteAsync(id);
            
                return Ok();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
            throw;
        }

        return NoContent();
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("label/{Id}")]
    public IActionResult DeleteLabel(int id)
    {
        try
        {
            if (id != null)
            {
                _labelRepo.DeleteAsync(id);
            
                return Ok();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
            throw;
        }

        return NoContent();
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("producer/{Id}")]
    public IActionResult DeleteProducer(int id)
    {
        try
        {
            if (id != null)
            {
                _producerRepo.DeleteAsync(id);
            
                return Ok();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
            throw;
        }

        return NoContent();
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("{Id}")]
    public IActionResult DeleteTrack(int id)
    {
        try
        {
            if (id != null)
            {
                _trackRepo.DeleteAsync(id);
            
                return Ok();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
            throw;
        }

        return NoContent();
    }
    
}