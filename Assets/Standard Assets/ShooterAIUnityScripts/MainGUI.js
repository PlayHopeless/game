//Main in-game GUI



Screen.showCursor = false; //disable cursor

function OnGUI()
{

//screen variables
var sw = Screen.width/2;
var sh = Screen.height/2;



//draw specified text
var textToDraw = "WASD + Mouse to move \n Press R to restart and see if there is a different outcome";

GUI.TextArea(Rect(10,10,textToDraw.Length*7,150), "WASD + Mouse to move \n Press R to restart and see if there is a different outcome \n \n \n \n The whole system is based on butterfly effects (eg. fear, andrenaline) which will effect the outcome. The AI reacts and thinks totally dynamically, meaning it will sometimes try out crazy stuff, but in other cases will react ingeniusly");




}