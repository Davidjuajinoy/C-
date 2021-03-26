using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TheCodeCamp.Data;
using TheCodeCamp.Models;

namespace TheCodeCamp.Controllers
{
    //para que sirve esta ruta hay comentar la de WebApiConfig
    [RoutePrefix("api/camps")]
    public class CampsController : ApiController
    {
        private readonly ICampRepository _repository;
        private readonly IMapper mapper;


        /// <summary>
        /// Definiendo constructor
        /// </summary>
        /// <param name="repository">es la base de datos</param>
        /// <param name="mapper">Es el automapper, tiene que que agregar el using AutoMapper</param>
        public CampsController(ICampRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this.mapper = mapper;
        }


        [Route()]
        public async Task<IHttpActionResult> Get(bool includeTalks = false)
        {

            try
            {
                var resultado = await _repository.GetAllCampsAsync(includeTalks);

                //var resultado = Json(await _repository.GetAllCampsAsync());
                //return resultado;

                /*mapper*/

                var mappedResult = mapper.Map<IEnumerable<CampModel>>(resultado);

                return Ok(mappedResult);

            }
            catch (Exception ex)
            {
                //TODO ADD LOGGIN
                return InternalServerError(ex);

            }
            //return BadRequest("NO sirve xd ");
            //return Ok(new { Name = "Shawn", Ocupation = "Profesor" });
        }


        // GET: api/Camps
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Camps/5


        [Route("{moniker}", Name = "GetCamp")]
        public async Task<IHttpActionResult> Get(string moniker, bool includeTalks = false)
        {
            try
            {
                var result = await _repository.GetCampAsync(moniker, includeTalks);

                if (result == null) return NotFound();

                return Ok(mapper.Map<CampModel>(result));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        //[Route("searchByDate")] //localhost:6600/api/camps/searchByDate?eventDate=2018-10-18
        //esta ruta hace que requiera el parametro eventDate y que sea definido de tipo datetime o sino falla
        [Route("searchByDate/{eventDate:Datetime}")] //localhost:6600/api/camps/searchByDate/2018-10-18

        [HttpGet] //se pone get porque el nombre no es get entonces hay que añadirle las propiedades http
        public async Task<IHttpActionResult> SearchByEvenData(DateTime eventDate, bool includeTalks = false)
        {
            try
            {
                var result = await _repository.GetAllCampsByEventDate(eventDate, includeTalks);
                return Ok(mapper.Map<CampModel[]>(result));
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }



        // POST: api/Camps
        [Route()]
        [HttpPost]
        public async Task<IHttpActionResult> Post(CampModel model)
        {
            try
            {
                //verifica que el moniker se unico
                if (await _repository.GetCampAsync(model.Moniker) != null)
                {
                    ModelState.AddModelError("Moniker", "El moniker debe ser unico");
                }

                // verifica que se cumplan lo parametrizado
                if (ModelState.IsValid)
                {
                    //se mapea alreves  los datos json recibidos a entidad Camp
                    var camp = mapper.Map<Camp>(model);
                    _repository.AddCamp(camp);

                    if (await _repository.SaveChangesAsync())
                    {
                        //se mapea para no mostrar la id y mostrar los datos a la forma de los modelos
                        var modelParaMostrar = mapper.Map<CampModel>(camp);

                        //se le asigna la ruta de GetCamp que es la que busca por moniker y se le asigna el parametro   
                        //var locacion = Url.Link("GetCamp", new { moniker = modelParaMostrar.Moniker });
                        //return Created(locacion ,modelParaMostrar);
                        //la locacion se puede ver en postman desde header
                        return CreatedAtRoute("GetCamp", new { moniker = modelParaMostrar.Moniker }, modelParaMostrar);

                    }

                    /*para validar los datos pedidos se puede desde el model de CampModel y ponerles [Require] o otras validaciones
                     */

                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            //return BadRequest("Error no se enviaron bien los datos");
            return BadRequest(ModelState);
        }

        // PUT: api/Camps/5
        [Route("{moniker}")]
        [HttpPut]
        public async  Task<IHttpActionResult> Put(string moniker, CampModel model)
        {
            try
            {
                var campByMoniker = await _repository.GetCampAsync(moniker);
                if (campByMoniker == null) return NotFound();

                //usar el automapper para actualizar campamentos (el primer parametro son los datos recibidos y el segundo parametro es a cual objeto hace referncia)
                mapper.Map(model, campByMoniker); 

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(mapper.Map<CampModel>(campByMoniker));
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

        // DELETE: api/Camps/5
        [Route("{moniker}")]
        public async Task<IHttpActionResult> Delete(string moniker)
        {
            try
            {
                var camp = await _repository.GetCampAsync(moniker);

                if (camp == null) return NotFound();

                _repository.DeleteCamp(camp);
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
