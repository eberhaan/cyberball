const ball = document.getElementById("ball");


const positions = {

    player1:{
        x:180,
        y:window.innerHeight-200
    },


    player2:{
        x:window.innerWidth-220,
        y:window.innerHeight-200
    },


    player3:{
        x:window.innerWidth/2,
        y:150
    }

};



let sequence;



if(condition=="1")
{

    // Inclusion:
    // Mensch bekommt Ball regelmäßig

    sequence=[
        "player1",
        "player2",
        "player1",
        "player3",
        "player1"

    ];

}

else
{

    // Exclusion:
    // Mensch wird weniger berücksichtigt

    sequence=[
        "player1",
        "player3",
        "player3",
        "player1",
        "player3"

    ];

}



let index=0;



function throwBall(from,to)
{

    let start=positions[from];
    let end=positions[to];


    ball.animate(

        [

            {
                left:start.x+"px",
                top:start.y+"px"
            },

            {
                left:end.x+"px",
                top:end.y+"px"
            }

        ],

        {
            duration:1500,
            fill:"forwards"

        }

    );

}



function nextThrow()
{

    let from=sequence[index];

    let to=sequence[index+1];


    if(!to)
    {
        index=0;
        return;
    }


    throwBall(from,to);


    index++;

}



setInterval(nextThrow,2500);
