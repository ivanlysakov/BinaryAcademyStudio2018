import { Fighter } from "./fighter";

export class ImprovedFighter extends Fighter {

    doubleHit(enemy, point) {
        super.hit(enemy, point * 2)
    };
};




