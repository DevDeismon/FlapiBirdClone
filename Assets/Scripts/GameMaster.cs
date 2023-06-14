using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

// TODO: Calcular el limite de spawn y velocidad de los elementos en pantalla para la dificultad.
// TODO: spawn limite : 2 float
// TODO: Velocidad de mov limite: --
// TODO: Cada 100 puntos se aumentara la velocidad 0.5 y el ratio de spwn se reducira en 0.3(?)
public class GameMaster : MonoBehaviour
{
    [SerializeField] private SpawnGeneralItems spawnGeneralItems;
    [SerializeField] private float spawnRatioReduction;
    [SerializeField] private int nextLevel; // Score limite para el siguiente level. NOTA: Subir el lvl cada 100 puntos?
    [SerializeField] private int maxScore; // Score Maximo para acabar la partida. NOTA: Score maximo 9999?
    private SpawnPipes spawnPipes;
    private GameObject scorePanel;
    private TextMeshProUGUI scorePoints;
    
    private void Update()
    {
        // 1. Mirar si exite la instancia de private GameObject scorePanel en la escena.
        if ()
        {

        }
        // 2. Si el primer paso es "true", inicializar las variables necesarias
        // 3. Si el primer paso es "true", comprobar si la puntuación a llegado a 999 y en caso de cierto acabar la partida.
        // 4. Si el segundo paso es "false", iniciar los procesos de aumentar la dificultad.
        // 4.1. Reducir el ratio de spawn de los objetos en -0.3 por cada múltiplo de 100 hasta un maximo de 2
        // 4.2. Aumentar la velocidad de movimiento de los objetos en (0.5-0.3) por cada múltiplo de 100 hasta un maximo de n
        // 5. Actualizar el limite en multiplo de 100 hasta un limite de 999.
    }

    private int GetScore()
    {
        return int.Parse(scorePoints.text);
    }

    private void SetGameMaster()
    { // TODO: revisar mejor la comprobación Va demasiado rapido, dar al meno un tiempo de 0.5f que es lo que tarda en instanciar los elementos
        if (!gameMasterInit)
        {
            scorePanel = GameObject.FindGameObjectWithTag("ScorePanel");
            scorePoints = scorePanel.GetComponentInChildren<TextMeshProUGUI>();
            spawnPipes = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<SpawnPipes>();
            gameMasterInit=true;
        }
        
    }
    //private void Update()
    //{
    //    if (spawnGeneralItems.gameStarted) {
    //        SetGameMaster();// TODO buscar una forma mejor

    //        if (GetScore() >= nextLevel)
    //        {
    //            float nextSpawnRatio = spawnPipes.GetspawnPipes() - 0.3f;
    //            if (nextSpawnRatio <= 2f)
    //            {
    //                nextSpawnRatio = 2f;
    //            }
    //            spawnPipes.SetSpawnPipes(nextSpawnRatio);
    //            // Setear la velocidad de las tuberias para que vayan mas rapidas.

    //            nextLevel += nextLevel;
    //        }
    //    }
    //    //if (maxScore >= GetScore()) // TODO: Mirar bien el filtro para acabar la partida.
    //    //{
    //    //    // Terminar el juego
    //    //}

    //}

}
