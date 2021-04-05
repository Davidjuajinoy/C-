using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TheCodeCamp.Data;
using TheCodeCamp.Models;

namespace TheCodeCamp.Controllers
{
    [RoutePrefix("api/camps/{moniker}/talks")]
    public class TalksController : ApiController
    {
        private readonly ICampRepository _repository;
        private readonly IMapper _mapper;

        public TalksController(ICampRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }


        [Route()]
        [HttpGet]
        public async Task<IHttpActionResult> Get(string moniker, bool includeSpeakers = false)
        {
            try
            {
                var talks = await _repository.GetTalksByMonikerAsync(moniker, includeSpeakers);

                return Ok(_mapper.Map<IEnumerable<TalkModel>>(talks));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("{idTalk:int}", Name ="GetByIdTalk")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(string moniker,int idTalk , bool includeSpeakers = false)
        {
            try
            {
                var talk = await _repository.GetTalkByMonikerAsync(moniker, idTalk, includeSpeakers);
                if (talk == null) return NotFound();
                return Ok(_mapper.Map<TalkModel>(talk));
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [Route()]
        [HttpPost]
        public async Task<IHttpActionResult> Create(String moniker,TalkModel model)
        {
            try
            {
                var camp = await _repository.GetCampAsync(moniker);

                if (camp != null)
                {
                    var talk = _mapper.Map<Talk>(model);
                    talk.Camp = camp;

                    //map speaker

                    if (model.Speaker != null)
                    {
                        var speaker = await _repository.GetSpeakerAsync(model.Speaker.SpeakerId);
                        if (speaker != null)
                        {
                            talk.Speaker = speaker;
                        }
                    }

                    _repository.AddTalk(talk);
                    if (await _repository.SaveChangesAsync() )
                    {
                        return CreatedAtRoute("GetByIdTalk", 
                            new { moniker = moniker, idTalk = talk.TalkId },
                            _mapper.Map<TalkModel>(talk));
                    }
                }
                
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            //manda los mensajes de error de validacion
            return BadRequest(ModelState);
        }


        [Route("{id:int}")]
        public async Task<IHttpActionResult> Put(string moniker, int id, TalkModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var talk = await _repository.GetTalkByMonikerAsync(moniker, id, true);
                    if (talk == null) return NotFound();
                    // ignora speaker se modifica en el MappingProfie
                    _mapper.Map(model, talk);

                    //si se cambia el speaker
                    if (talk.Speaker.SpeakerId != model.Speaker.SpeakerId)
                    {
                        //se cambia el speaker id por el insertado en el model
                        var speaker = await _repository.GetSpeakerAsync(model.Speaker.SpeakerId);
                        if (speaker != null) talk.Speaker = speaker;
                    }

                    if (await _repository.SaveChangesAsync())
                    {
                        return Ok(_mapper.Map<TalkModel>(talk));
                    }
                }
                  
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return BadRequest(ModelState);
            
        }

        [Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(string moniker, int id)
        {
            try
            {
                var talk = await _repository.GetTalkByMonikerAsync(moniker, id);

                _repository.DeleteTalk(talk);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return InternalServerError();
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

           
        }
    }

}
