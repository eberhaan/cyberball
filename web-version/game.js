// Cyberball 5 Web Version


let condition =
    new URLSearchParams(window.location.search)
    .get("condition")
    || 1;


let participant =
    new URLSearchParams(window.location.search)
    .get("participant")
    || "test";


let throwNumber = 0;

let maxThrows = 30;


let history=[];



const message =
document.getElementById("message");


const choices =
document.getElementById("choices");



function startGame(){

message.innerHTML =
"Game started. You have the ball.";

choices.style.display="block";

}


function throwBall(target){


throwNumber++;


history.push({
    throw:throwNumber,
    from:"human",
    to:"player"+target
});


animateBall(target);



setTimeout(()=>{


aiTurn();


},1500);



}



function animateBall(target){


message.innerHTML =
"You threw to Player "+target;


}



function aiTurn(){


if(throwNumber>=maxThrows){

endGame();
return;

}



let target;



if(condition==1){

// INCLUSION
// KI wirft häufig zum Menschen

let r=Math.random();


if(r<0.5)
target="human";
else
target="player"+(Math.random()<0.5?1:3);


}


else{


// EXCLUSION
// KI spielt hauptsächlich miteinander

target=
Math.random()<0.8
?
"player1"
:
"player3";


}



history.push({

throw:throwNumber,
from:"AI",
to:target

});



message.innerHTML=
"AI throws to "+target;



setTimeout(()=>{

message.innerHTML=
"Your turn";

},1500);



}



function endGame(){


localStorage.setItem(
"cyberball_"+participant,
JSON.stringify(history)
);



message.innerHTML=
"Finished";


window.location.href=
"finish.html?condition="
+condition
+"&throws="
+history.length;



}



startGame();
