using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SportController : ControllerBase
    {
        public SkolaSportaContext Context{get; set;}
        public SportController(SkolaSportaContext context)
        {
            Context=context;
        }

        [Route("PreuzmiSkoleSporta")]
        [HttpGet]
        public async Task<List<SkolaSporta>> PreuzmiSkoleSporta()
        {
            return await Context.SkoleSporta.Include(p=>p.sportovi).ToListAsync();
            
        }

        [Route("PreuzmiSportove")]
        [HttpGet]
        public async Task<List<Sport>> PreuzmiSportove(int IDskole)
        {
            return await Context.sportovi.Where(sport=>sport.SkolaSporta.ID==IDskole).Include(sp=>sp.DeteSport).ThenInclude(p => p.Dete).ToListAsync();
        }

        [Route("PreuzmiDecu/{ID}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiDecu(int ID)
        {
            var vred = await Context.Deca.Include(p => p.Roditelj)
                                        .Include(p=>p.SportDete)
                                        .ThenInclude(p => p.Sport)
                                        .Where(p => p.SportDete.Any(q => q.Sport.ID == ID)).ToListAsync();
            return Ok( vred.Select(p => new
            {
                p.ID,
                DeteIme = p.Ime,
                DetePrezime = p.Prezime,
                p.Godine,
                p.JMBG,
                RoditeljIme = p.Roditelj.Ime,
                RoditeljPrezime = p.Roditelj.Prezime,
                RoditeljTelefon=p.Roditelj.BrTel,
                RoditeljEmail=p.Roditelj.Email,
                Sportovi = p.SportDete.Select(q => new
                {
                    q.DatumUpisa,
                    q.Sport.Vrsta
                })
            }));
        }
        
        
        [Route("UpisiSkoluSporta")]
        [HttpPost]
        public async Task UpisiSkolu([FromBody] SkolaSporta skola)
        {
            Context.SkoleSporta.Add(skola);
            await Context.SaveChangesAsync();
        }

        [Route("UpisiSport")]
        [HttpPost]
        public async Task UpisiSportUSkolu(int idSkole,string vrsta,int maxbr,int trenbr,int cena) 
        {
            Sport sport=new Sport();

            sport.Vrsta=vrsta;
            sport.MaxBrojDece=maxbr;
            sport.TrenBrojDece=trenbr;
            sport.Cena=cena;
            var skola=await Context.SkoleSporta.FindAsync(idSkole);
            sport.SkolaSporta=skola;

            Context.sportovi.Add(sport);
            await Context.SaveChangesAsync();
        }

        [Route("UpisiDete/{idSporta}/{ime}/{prezime}/{imerod}/{prez}/{tel}/{em}/{god}/{JMBG}")]
        [HttpPost]
        public async Task UpisiDete(int idSporta,string ime,string prezime,string imerod,string prez,string tel,string em,int god,string JMBG)
        {
            if( ime!=null && prezime!=null && imerod!=null && prez!=null && em!=null && god>2 && god<15){
            Dete  dete = new Dete();
            dete.Ime=ime;
            dete.Prezime=prezime;
          
            dete.Roditelj=new Roditelj();
            dete.Roditelj.Ime=imerod;
            dete.Roditelj.Prezime=prez;
            dete.Roditelj.BrTel=tel;
            dete.Roditelj.Email=em;
            
            dete.Godine=god;
            dete.JMBG=JMBG;
             
             
            var sport=await Context.sportovi.FindAsync(idSporta);
            
            Spoj spoj = new Spoj
            {
                Dete = dete,
                Sport = sport,
                DatumUpisa = DateTime.Now
            };

          sport.TrenBrojDece++;
            

            
            Context.Deca.Add(dete);

            Context.DecaISportovi.Add(spoj);

            await Context.SaveChangesAsync();
            }
        }

        [Route("ObrisiDete/{idSporta}/{idDeteta}")]
        [HttpDelete]
        public async Task<IActionResult> ObrisiDete(int idSporta, string idDeteta)
        {
            Dete dete = await Context.Deca.Where(p => p.JMBG == idDeteta).FirstOrDefaultAsync();

            

            var d = await Context.DecaISportovi.Include(p => p.Dete).Include(p => p.Sport)
                        .Where(p => p.Dete.JMBG == dete.JMBG)
                        .Where(p => p.Sport.ID == idSporta)
                        .FirstOrDefaultAsync();

            if(d!=null)
            {
               Context.Deca.Remove(d.Dete);
               d.Sport.TrenBrojDece--;

               Context.DecaISportovi.Remove(d);

               await Context.SaveChangesAsync();
               return Ok();

            }
            else
               return StatusCode(404);
        }

        [Route("ObrisiSport")]
        [HttpDelete]
        public async Task<IActionResult> ObrisiSport(int idSkole,[FromBody] Sport sport)
        {
            var w=Context.sportovi.Where(p=>p.SkolaSporta.ID==idSkole && p.Vrsta==sport.Vrsta).FirstOrDefault();

            if(w!=null)
            {
                var x=await Context.DecaISportovi.Include(p => p.Sport).Where(d=>d.Sport.ID==w.ID).ToListAsync();
                x.ForEach(spoj=>{
                    Context.DecaISportovi.Remove(spoj);
                });
                Context.sportovi.Remove(w);
                await Context.SaveChangesAsync();
                return Ok();
            }
            else
                return StatusCode(404);
        }

        [HttpDelete]
        [Route("ObrisiSkoluSporta")]
        public async Task ObrisiSkoluSporta(int id)
        {
            var sk=await Context.SkoleSporta.FindAsync(id);
            var spo=await Context.sportovi.Where(z=>z.SkolaSporta==sk).ToListAsync();
            spo.ForEach(sport=>
            {
                var det=Context.DecaISportovi.Where(x=>x.Sport==sport).ToList();
                det.ForEach(spoj=>{
                    Context.DecaISportovi.Remove(spoj);
                });
                    Context.sportovi.Remove(sport);
            });
            Context.SkoleSporta.Remove(sk);
            await Context.SaveChangesAsync();
        }
       

       [Route("IzmeniSkoluSportova")]
       [HttpPut]
       public async Task IzmeniSkoluSporta(SkolaSporta skola)
       {
           Context.SkoleSporta.Update(skola);
           await Context.SaveChangesAsync();
       }

       [Route("IzmeniSport")]
       [HttpPut]
       public async Task<IActionResult> IzmeniSport([FromBody] Sport sport)
       {
           try
           {
               Context.Update<Sport>(sport);
               await Context.SaveChangesAsync();
               return Ok();

           }
           catch
           {
               return StatusCode(404);
           }
       }

       [Route("IzmeniDete")]
       [HttpPut]
       public async Task<IActionResult> IzmeniDete([FromBody] Dete dete)
       {
           try
           {
               if (dete == null)
               {
                   return BadRequest("Dete nije poslato na pravi nacin.");
               }

               var bazaDete = await Context.Deca.Where(p => p.JMBG == dete.JMBG).FirstOrDefaultAsync();

               if (bazaDete == null)
               {
                   return BadRequest("Dete sa ovim JMBG brojem ne postoji u bazi podataka.");
               }


                if (!string.IsNullOrWhiteSpace(dete.Ime))
                {
                    bazaDete.Ime = dete.Ime;
                }

                if (!string.IsNullOrWhiteSpace(dete.Prezime))
                {
                    bazaDete.Prezime = dete.Prezime;
                }

                if (dete.Godine > 2 && dete.Godine < 15)
                {
                    bazaDete.Godine = dete.Godine;
                }


               Context.Update<Dete>(bazaDete);
               await Context.SaveChangesAsync();
               return Ok(bazaDete);
           }
           catch (Exception e)
           {
               return StatusCode(404, e.Message);
           }
       }
    }
}
