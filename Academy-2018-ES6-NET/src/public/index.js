import { Fighter } from "./fighter";
import { ImprovedFighter } from "./improvedFighter";
import fightClub from "./fight";

var redCorner = new Fighter("Joe Frazier", 7, 500)
var blueCorner = new ImprovedFighter("Muhammad Ali", 15, 1000)

fightClub(redCorner, blueCorner, 50, 10, 20, 20, 11, 15, 75, 60, 20);



