using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using game;
using Porjet_C_;

namespace Porjet_C_
{
    public class GameData
    {
        public GameData() 
        {
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
            |                                  Pokemons                                           |
            |                                                                                     |
            |                                                                                     |
            *///----------------------------------------------------------------------------------|


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
