namespace Porjet_C_
{
    public struct GameData
    {
        List<GameObject> _pokemonList;
        List<Attack> _attackList;

        public List<GameObject> PokemonList { get => _pokemonList; set => _pokemonList = new(); }
        public List<Attack> AttackList { get => _attackList; set => _attackList = new(); }

        public void setGameData()
        {
            AttackList attackList = new AttackList();

            PokemonList = new List<GameObject>();
            AttackList = new List<Attack>();


            /*//----------------------------------------------------------------------------------|
            |                                                                                     |
            |                                                                                     |
            |                                  Types                                              |
            |                                                                                     |
            |                                                                                     |
            *///----------------------------------------------------------------------------------|

            Types normalType = new Types("normal");
            Types lightType = new Types("light");
            Types voidType = new Types("void");
            Types cyberType = new Types("cyber");
            Types primalType = new Types("primal");
            Types mysticType = new Types("mystic");
            Types rythmType = new Types("rythm");


            //Normal Type
            normalType.AddStrength(rythmType);
            normalType.AddStrength(mysticType);
            normalType.AddWeakness(cyberType);
            normalType.AddWeakness(primalType);

            //Light Type
            lightType.AddStrength(voidType);
            lightType.AddStrength(primalType);
            lightType.AddWeakness(mysticType);

            //Void Type
            voidType.AddStrength(lightType);
            voidType.AddStrength(rythmType);
            voidType.AddWeakness(mysticType);

            //Cyber Type
            cyberType.AddStrength(normalType);
            cyberType.AddStrength(mysticType);
            cyberType.AddWeakness(rythmType);

            //Primal Type
            primalType.AddStrength(normalType);
            primalType.AddStrength(rythmType);
            primalType.AddWeakness(lightType);
            primalType.AddWeakness(mysticType);

            //Mystic Type
            mysticType.AddStrength(primalType);
            mysticType.AddStrength(lightType);
            mysticType.AddStrength(voidType);
            mysticType.AddWeakness(normalType);
            mysticType.AddWeakness(cyberType);

            //Rythm Type
            rythmType.AddStrength(cyberType);
            rythmType.AddWeakness(primalType);
            rythmType.AddWeakness(voidType);
            rythmType.AddWeakness(normalType);


            /*//----------------------------------------------------------------------------------|
            |                                                                                     |
            |                                                                                     |
            |                                  Attacks                                            |
            |                                                                                     |
            |                                                                                     |
            *///----------------------------------------------------------------------------------|

            Attack novaStrike = new Attack("Nova Strike", voidType, 300, attackList.novaStrike) ;
            AttackList.Add(novaStrike);
            Attack stellarRoar = new Attack("Stellar Roar", mysticType, 300, attackList.stellarRoar);
            AttackList.Add(novaStrike);
            Attack lunarShield = new Attack("Lunar Shield", mysticType, 300, attackList.lunarShield);
            AttackList.Add(novaStrike);
            Attack celestialBeam = new Attack("Celestial Beam", lightType, 300, attackList.celestialBeam);
            AttackList.Add(novaStrike);

            /*//----------------------------------------------------------------------------------|
            |                                                                                     |
            |                                                                                     |
            |                                  Objects                                            |
            |                                                                                     |
            |                                                                                     |
            *///----------------------------------------------------------------------------------|


            /*//----------------------------------------------------------------------------------|
            |                                                                                     |
            |                                                                                     |
            |                                  Pokemons                                           |
            |                                                                                     |
            |                                                                                     |
            *///----------------------------------------------------------------------------------|


            GameObject astraleon = new GameObject();
            Component astraleonStat = new Pokemon("astraleonStat", 1, 0, 100, mysticType, 3, 1, 2, 15, 15, false);
            Component astraleonRender = new Render("astraleonRender", "f");
            ((Pokemon)astraleonStat).setAttack(novaStrike);
            ((Pokemon)astraleonStat).setAttack(stellarRoar);
            ((Pokemon)astraleonStat).setAttack(lunarShield);
            ((Pokemon)astraleonStat).setAttack(celestialBeam);
            astraleon.AddComponent(astraleonStat);
            PokemonList.Add(astraleon);
            

            /*
            List<Types> types = new List<Types>();
            types.Add(electricType);    
            GameObject pikachu = new GameObject();
            Component pikachuStat = new Pokemon();
            pikachu.AddComponent(pikachuStat);
            */

        }






    }
}
