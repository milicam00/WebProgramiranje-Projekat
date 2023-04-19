export class Dete
{
    constructor(ime,prezime,godine,jMBG,imerod,prezimerod,brtel,email,datum)
    {
        this.deteIme=ime;
        this.detePrezime=prezime;
        this.godine=godine;
        this.jmbg=jMBG;
        this.roditeljIme=imerod;
        this.roditeljPrezime=prezimerod;
        this.roditeljTelefon=brtel;
        this.roditeljEmail=email;
        this.datumUpisa=new Date(datum).toLocaleDateString("sr");
        this.sportovi=[];
        

    }
    
    crtaj(host, skolaKont)
    {
        var tr=document.createElement("tr");
        tr.className="tr";
        host.appendChild(tr);

        var el=document.createElement("td");
        var dugme = document.createElement("button");
        dugme.value = "Izmeni";
        dugme.innerText = "Izmeni";

        
        dugme.onclick = () => {
          
            skolaKont.querySelector(".inputImeDeteta").value = this.deteIme;
            skolaKont.querySelector(".inputPrezimeDeteta").value = this.detePrezime;
            skolaKont.querySelector(".inputGodineDeteta").value = this.godine;
            skolaKont.querySelector(".inputJMBG").value = this.jmbg;
            skolaKont.querySelector(".inputImeRoditelja").value = this.roditeljIme;
            skolaKont.querySelector(".inputPrezimeRoditelja").value = this.roditeljPrezime;
            skolaKont.querySelector(".inputTelefon").value = this.roditeljTelefon;
            skolaKont.querySelector(".inputEmailRoditelja").value = this.roditeljEmail;
        };
        el.appendChild(dugme);
        el.className="td";
        tr.appendChild(el);

       var el=document.createElement("td");
        el.innerHTML=this.deteIme;
        el.className="td";
        tr.appendChild(el);

         el=document.createElement("td");
        el.innerHTML=this.detePrezime;
        el.className="td";
        tr.appendChild(el);

         el=document.createElement("td");
        el.innerHTML=this.godine;
        el.className="td";
        tr.appendChild(el);

        el=document.createElement("td");
        el.innerHTML=this.jmbg;
        el.className="td";
        tr.appendChild(el);

         el=document.createElement("td");
        el.innerHTML=this.roditeljIme;
        el.className="td";
        tr.appendChild(el);

         el=document.createElement("td");
        el.innerHTML=this.roditeljPrezime;
        el.className="td";
        tr.appendChild(el);

         el=document.createElement("td");
        el.innerHTML=this.roditeljTelefon;
        el.className="td";
        tr.appendChild(el);

        el=document.createElement("td");
        el.innerHTML=this.roditeljEmail;
        el.className="td";
        tr.appendChild(el);

        el=document.createElement("td");
        el.innerHTML=this.datumUpisa;
        el.className="td";
        tr.appendChild(el);
       
    }



}