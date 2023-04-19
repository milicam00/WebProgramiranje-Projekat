import { Dete } from "./Dete.js";
import { Sport } from "./Sport.js";
export class SkolaSporta
{
    constructor(listaSportova,naziv,adresa,broj,email)
    {
        this.listaSportova=listaSportova;
        this.naziv=naziv;
        this.adresa=adresa;
        this.broj=broj;
        this.email=email;
        this.kont=null;
    }

    crtaj(host)
    {
        if(!this.kont)
       {
        this.kont=document.createElement("div");
        this.kont.className="GlavniKontejner";



       const h2 = document.createElement("h2");
        h2.innerHTML = `Skola sporta "${this.naziv}"`;
        h2.className = "naslov";
        host.appendChild(h2);
        host.appendChild(this.kont);

        this.crtajFormu(this.kont);
       this.crtajTabelu(this.kont);
       }
        
    }

    crtajFormu(roditelj)
    {

        let divf=document.createElement("div");
        divf.className="divForma";
        roditelj.appendChild(divf);

        var formDete=document.createElement("div");
        formDete.className="formDete";
        divf.appendChild(formDete);

      

        this.crtajFormuDete(formDete);

     

    }
    crtajTabelu(roditelj)
    {
        let divt=document.createElement("div");
        divt.className="divTabela";
        roditelj.appendChild(divt);

        var tabela=document.createElement("table");
        tabela.className="tabela";
        divt.appendChild(tabela);

        var tabelahead=document.createElement("thead");
        tabela.appendChild(tabelahead);

        var tr=document.createElement("tr");
        tabelahead.appendChild(tr);

        var tabelaBody=document.createElement("tbody");
        tabelaBody.className="TabelaPodaci";
        tabela.appendChild(tabelaBody);

        let th;
        var zaglavlje=["Izmeni", "Ime deteta","Prezime deteta","Godine","JMBG","Ime roditelja","Prezime roditelja","Broj telefona","Email roditelja","Datum upisa"];
        zaglavlje.forEach(el=>{
            th=document.createElement("th");
            th.innerHTML=el;    
            tr.appendChild(th);
        })
    }
   

    crtajFormuDete(formDete)
    {
        var lab=document.createElement("h3");
        lab.className="labUnosNaslov";
        lab.innerHTML="Prijava deteta u skolu sporta";
        formDete.appendChild(lab);
        //ime
        lab=document.createElement("label");
        lab.innerHTML="Ime deteta:";
        lab.className="lab";
        formDete.appendChild(lab);

        let inp=document.createElement("input");
        inp.className="inputImeDeteta";
        formDete.appendChild(inp);

        //prezime
        let  labPrezime=document.createElement("label");
        labPrezime.innerHTML="Prezime deteta:";
        labPrezime.className="lab";
        formDete.appendChild(labPrezime);

        let inpPrezime=document.createElement("input");
        inpPrezime.className="inputPrezimeDeteta";
        formDete.appendChild(inpPrezime);

        //godine
        let labGodine=document.createElement("label");
        labGodine.innerHTML="Godine:";
        labGodine.className="lab";
        formDete.appendChild(labGodine);

        let inpGodine=document.createElement("input");
        inpGodine.className="inputGodineDeteta";
        inpGodine.type="number";
        formDete.appendChild(inpGodine);

        //jmbg
        let  labJMBG=document.createElement("label");
        labJMBG.innerHTML="JMBG deteta:";
        labJMBG.className="lab";
        formDete.appendChild(labJMBG);

        let inpJMBG=document.createElement("input");
        inpJMBG.className="inputJMBG";
        formDete.appendChild(inpJMBG);

        //ime rod
       let labImeRod=document.createElement("label");
        labImeRod.innerHTML="Ime roditelja:";
        labImeRod.className="lab";
        formDete.appendChild(labImeRod);

        let inpImeRod=document.createElement("input");
        inpImeRod.className="inputImeRoditelja";
        formDete.appendChild(inpImeRod);

        //prezime rod
        let  labPrezimeRod=document.createElement("label");
        labPrezimeRod.innerHTML="Prezime roditelja:";
        labPrezimeRod.className="lab";
        formDete.appendChild(labPrezimeRod);

        let inpPrezimeRod=document.createElement("input");
        inpPrezimeRod.className="inputPrezimeRoditelja";
        formDete.appendChild(inpPrezimeRod);

        //brtel
        let labTel=document.createElement("label");
        labTel.innerHTML="Broj telefona:";
        labTel.className="lab";
        formDete.appendChild(labTel);

        let inpTel=document.createElement("input");
        inpTel.className="inputTelefon";
        formDete.appendChild(inpTel);

      
         //email
         let labEmail=document.createElement("label");
         labEmail.innerHTML="Email roditelja:";
         formDete.appendChild(labEmail);
         labEmail.className="lab";
 
         let inpEmail=document.createElement("input");
         inpEmail.className="inputEmailRoditelja";
         formDete.appendChild(inpEmail);

         //vrsta sporta
         let l=document.createElement("label");
         l.innerHTML="Vrsta sporta: ";
        formDete.appendChild(l);

        let se=document.createElement("select");
        se.className="select";
        formDete.appendChild(se);


        console.log(this.listaSportova);

        let op;
        this.listaSportova.forEach(s => {
            op=document.createElement("option");
            op.innerHTML=s.vrsta;
            op.value=s.id;
            se.appendChild(op);
        });
        
        
        
        const btnDodajDete=document.createElement("button");
        btnDodajDete.innerHTML="Dodaj dete ";
        btnDodajDete.onclick=(ev)=>this.upisi(inp.value,inpPrezime.value,inpGodine.value,inpJMBG.value,inpImeRod.value,inpPrezimeRod.value,inpTel.value,inpEmail.value);
      
        btnDodajDete.className="dugme";
        formDete.appendChild(btnDodajDete);


        let btnPrikazi=document.createElement("button");
        btnPrikazi.className="dugme";
        btnPrikazi.onclick=(ev)=>this.NadjiDecu();
        btnPrikazi.innerHTML="Prikazi decu na ovom sportu";
        formDete.appendChild(btnPrikazi);

        let btnIzmeni=document.createElement("button");
        btnIzmeni.className="dugme";
        btnIzmeni.innerHTML="Izmeni informacije o detetu";
        btnIzmeni.onclick=(ev)=>this.izmeni();
        formDete.appendChild(btnIzmeni);

        let btnIspisi=document.createElement("button");
        btnIspisi.className="dugme";
        btnIspisi.innerHTML="Ispisi dete iz skole";
        btnIspisi.onclick=ev=>this.obrisi(inp.value,inpPrezime.value,inpGodine.value,inpJMBG.value,inpImeRod.value,inpPrezimeRod.value,inpTel.value,inpEmail.value);
        formDete.appendChild(btnIspisi);
      
    }
    
    obrisi(ime,prezime,godine,jmbg,imerod,prezimerod,tel,email)
    {
        if(jmbg==="")
        {
            alert("Unesite JMBG deteta!");
        }
        
        let optionEl=this.kont.querySelector("select");
        var sportID=optionEl.options[optionEl.selectedIndex].value;

        fetch("https://localhost:5001/Sport/ObrisiDete/"+sportID+"/"+jmbg,
        {
            method: "DELETE",
            "Content-Type": "application/json"
        }
        )

    }
    upisi(ime,prezime,godine,jmbg,imerod,prezimerod,tel,email)
    {
        if(ime==="")
        {
            alert("Unesite ime deteta!");
        }
        if(prezime==="")
        {
            alert("Unesite prezime deteta!");
        }
        if(godine===null || godine===undefined || godine==="")
        {
            alert("Unesite koliko Vase dete ima godina!");
        }
        else
        {
            let godineParse=parseInt(godine);
            if(godineParse<3 || godineParse>14)
            {
                alert("Skolu sporta mogu da upisu deca od 3 do 14 godina!");
            }
        }
        if(imerod==="")
        {
            alert("Unesite Vase ime!");
        }
        if(jmbg==="")
        {
            alert("Unesite JMBG deteta!");
        }
        if(prezimerod==="")
        {
            alert("Unesite Vase prezime!");
        }
        if(tel==="")
        {
            alert("Unesite broj telefona!");
        }
        if(email==="")
        {
            alert("Unesite email!");
        }

        let optionEl=this.kont.querySelector("select");
        var sportID=optionEl.options[optionEl.selectedIndex].value;
        console.log("ime"+ime);
        console.log("prezime "+prezime);
        console.log("godine "+godine);
        console.log("ime rod "+imerod);
        console.log("prez rod "+prezimerod);
        console.log("tel "+tel);
        console.log("email "+email);
        console.log("sport "+sportID);
        console.log("jmbg "+jmbg);

     

    fetch("https://localhost:5001/Sport/UpisiDete/"+sportID+"/"+ime+"/"+prezime+
    "/"+imerod+"/"+prezimerod+"/"+tel+"/"+email+"/"+godine+"/"+jmbg,
    {
        method:"POST"
    }).then(s=>{
        if(s.ok){
            s.text().then(dt=>{
                console.log(dt);
                
                var np=new Dete(dt.deteIme,dt.detePrezime,dt.godine,dt.jmbg,dt.roditeljIme,dt.roditeljPrezime,dt.roditeljTelefon,dt.sportovi[0].datumUpisa);
                console.log(np);
            })
        }

    })
    }
    izmeni()
    {

        let ime=this.kont.querySelector(".inputImeDeteta").value;
        let prez=this.kont.querySelector(".inputPrezimeDeteta").value;
        let god=this.kont.querySelector(".inputGodineDeteta").value;
        let jmbg=this.kont.querySelector(".inputJMBG").value;
       console.log(ime);
       console.log(prez);
       console.log(god);
        fetch("https://localhost:5001/Sport/IzmeniDete",
        {
            method: "PUT",
            headers:{
                "Content-Type": "application/json"
        },
        body: JSON.stringify({
            "ime": ime,
            "prezime": prez,
            "godine": god,
            "jmbg": jmbg
        })
        }).then(p => p.text().then(q => console.log(q)));

        
    
    }
  
    NadjiDecu()
    {
        let optionEl=this.kont.querySelector("select");
        var sportID=optionEl.options[optionEl.selectedIndex].value;
        console.log(sportID);
        
       this.ucitajDecu(sportID);
    }

  ucitajDecu(sportID)
    {
        fetch("https://localhost:5001/Sport/PreuzmiDecu/"+sportID,
        {
            method:"GET"
        }
        
        ).then(s=>{
            if(s.ok)
            {
                var teloTabele=this.obrisiPrethodniSadrzaj();
                s.json().then(data=>{
                  data.forEach(s=>{
                       
                        let dete=new Dete(s.deteIme,s.detePrezime,s.godine,s.jmbg,s.roditeljIme,s.roditeljPrezime,s.roditeljTelefon,s.roditeljEmail,s.sportovi[0].datumUpisa);
                        dete.crtaj(teloTabele, this.kont);
                    })
                   console.log(data);
                })
                    
            }
        })

    }

    obrisiPrethodniSadrzaj()
    {
        var teloTabele=this.kont.querySelector(".TabelaPodaci");
        var roditelj=teloTabele.parentNode;
        roditelj.removeChild(teloTabele);

        teloTabele=document.createElement("tbody");
        teloTabele.className="TabelaPodaci";
        roditelj.appendChild(teloTabele);
        return teloTabele;
    }
    dodajDete(dete)
    {
        if(!dete)
        {
            throw new error("Dete ne postoji!");
        }
        this.listaDece.push(dete);
    }
    
    nadjiDete(JMBG)
    {
        return this.listaDece.find(el=>el.jMBG==JMBG);
    }
    

}