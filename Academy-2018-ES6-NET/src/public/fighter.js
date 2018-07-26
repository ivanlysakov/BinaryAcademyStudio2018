export class Fighter {
    constructor(name, power, health) {
        this.name = name;
        this.power = power;
        this.health = health;
    }

    setDamage(damage) {
        this.health -= damage;
        console.log(`${this.name} has ${this.health} HP`);
    };

    hit(enemy, point) {
        let damage = point * this.power;
        enemy.setDamage(damage);
    };

    knockout() {
        return new Promise(resolve => {
            setTimeout(() => {
                console.log("Time is over!!!");
                resolve();
            }, 500);
        });
    };


};

