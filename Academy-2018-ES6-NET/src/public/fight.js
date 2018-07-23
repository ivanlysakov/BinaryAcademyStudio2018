export default async function fight(fighter, improvedFighter, ...points) {

    console.log("Ladies and gentlemen!! Are you ready??")
    console.log("Let's Get Ready To Rumble!!")
    console.log("**************************************")

    for (let i = 0; i < points.length; i++) {
        let attack = (i % 2 === 0) ? fighter : improvedFighter;
        let defense = (i % 2 === 0) ? improvedFighter : fighter;
        
        console.log(`${attack.name} hits!`)
        attack.hit(defense, points[i]);
       
        if (defense.health <= 0) {
            await defense.knockout();
            console.log("*****************************")
            console.log(`${defense.name} in knockout! ${attack.name} wins!!!`);
            return;
        }
    }s
    console.log("**************************************")
    console.log("RRRRRRROUND!!!")
};

export { fight as fightClub };

