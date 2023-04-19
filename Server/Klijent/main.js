import { SkolaSporta } from "./SkolaSporta.js";
import { Sport } from "./Sport.js";







fetch("https://localhost:5001/Sport/PreuzmiSkoleSporta")
.then(p=>{
    p.json().then(skole=>
        {
            skole.forEach(skola=>{

                var listaSportova2 = [];

                fetch("https://localhost:5001/Sport/PreuzmiSportove?IDskole="+skola.id)
                .then(p=>{
                    p.json().then(sportovii=>{
                        sportovii.forEach(sp => {
                           
                            var p=new Sport(sp.id,sp.vrsta);
                            listaSportova2.push(p);
                            
                        });

                        var sk=new SkolaSporta(listaSportova2, skola.naziv, skola.adresa, skola.broj, skola.email);
                        sk.crtaj(document.body);
                    })
                })
              
              
            });

        })
})

