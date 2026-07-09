let condition =
new URLSearchParams(window.location.search)
.get("condition");


let throws = [];


if(condition=="1"){

throws=[

"p3",
"human",
"any",
"p3",
"p1",
"human",
"any",
"p1",
"human",
"any"

];

}



else {


throws=[

"p3",
"p1",
"any",
"p3",
"p1",
"p3",
"p1",
"p3",
"p1"

];


}



let current=0;


document
.getElementById("start")
.onclick=function(){

document
.getElementById("welcome")
.style.display="none";


this.style.display="none";


document
.getElementById("field")
.style.display="block";


nextThrow();


};





function nextThrow(){


if(current>=throws.length){

document
.getElementById("choice")
.innerHTML=
"<h2>Spiel beendet</h2>";

return;

}



let target=throws[current];

current++;



if(target=="human"){


showChoice();


}

else{


automaticThrow(target);


}



}




function automaticThrow(target){


let ball=document.getElementById("ball");


let player=document.getElementById(target);


ball.style.left=
player.offsetLeft+"px";


ball.style.top=
player.offsetTop+"px";


setTimeout(nextThrow,2000);


}





function showChoice(){


document
.getElementById("choice")
.innerHTML=
`

<p>Wem möchten Sie den Ball zuwerfen?</p>

<button class="choicebutton"
onclick="choose('p1')">
Spieler 1
</button>


<button class="choicebutton"
onclick="choose('p3')">
Spieler 3
</button>

`;

}



function choose(player){


let ball=document.getElementById("ball");


let p=document.getElementById(player);


ball.style.left=
p.offsetLeft+"px";


ball.style.top=
p.offsetTop+"px";


document
.getElementById("choice")
.innerHTML="";


setTimeout(nextThrow,2000);


}

