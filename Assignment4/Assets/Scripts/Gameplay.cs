/*
 * Gerard Lamoureux
 * UpdateBakeTimer
 * Assignment 4
 * Handles Overall Gameplay
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Gameplay : MonoBehaviour
{
    public static Gameplay ThisGameplay;

    public List<Cake> currentOrders = new List<Cake>();

    private Cake playerCurrentCake;

    Coroutine bakeRoutine;

    private bool playerCakeBaked = false;

    private int bakeTimer = 0;

    private float moneyEarned = 0;

    private int cakesDelivered = 0;

    public int BakeTimer { get => bakeTimer; }

    private int gameTimer = 180;

    [SerializeField] private GameObject ingredientsButtons;

    [SerializeField] private TextMeshProUGUI lastIngredientText;

    [SerializeField] private TextMeshProUGUI gameTimerText;

    [SerializeField] private TextMeshProUGUI cakesDeliveredText;

    [SerializeField] private TextMeshProUGUI currentOrderText;

    [SerializeField] private TextMeshProUGUI currentCakeText;

    [SerializeField] private TextMeshProUGUI deliverCakeText;

    [SerializeField] private TextMeshProUGUI winLossText;

    [SerializeField] private GameObject baseGameUI;

    [SerializeField] private GameObject gameOverUI;

    bool gameOver = false;

    bool win = false;
    private void Awake()
    {
        ThisGameplay = this;
    }

    public void CreateNewIceCreamCake()
    {
        playerCakeBaked = false;
        playerCurrentCake = new IceCreamCake();

    }
    public void CreateNewChocolateCake()
    {
        playerCakeBaked = false;
        playerCurrentCake = new ChocolateCake();
    }
    public void CreateNewVanillaCake()
    {
        playerCakeBaked = false;
        playerCurrentCake = new VanillaCake();
    }

    public void AddCakeDecorator(int ingredNum)
    {
        if(playerCurrentCake != null && playerCakeBaked)
        {
            switch (ingredNum)
            {
                case 0:
                    playerCurrentCake = new BaseIcing(playerCurrentCake);
                    lastIngredientText.text = "Last Ingredient:\nBase Icing Layer";
                    break;
                case 1:
                    playerCurrentCake = new IcingDesigns(playerCurrentCake);
                    lastIngredientText.text = "Last Ingredient:\nIcing Designs";
                    break;
                case 2:
                    playerCurrentCake = new BirthdayCandle(playerCurrentCake);
                    lastIngredientText.text = "Last Ingredient:\nBirthday Candle";
                    break;
                case 3:
                    playerCurrentCake = new PlasticFigurine(playerCurrentCake);
                    lastIngredientText.text = "Last Ingredient:\nPlastic Figurine";
                    break;
                case 4:
                    playerCurrentCake = new PorcelainFigurine(playerCurrentCake);
                    lastIngredientText.text = "Last Ingredient:\nPorcelain Figurine";
                    break;
                case 5:
                    playerCurrentCake = new Sprinkles(playerCurrentCake);
                    lastIngredientText.text = "Last Ingredient:\nSprinkles";
                    break;
                case 6:
                    playerCurrentCake = new CrushedCookies(playerCurrentCake);
                    lastIngredientText.text = "Last Ingredient:\nCrushed Cookies";
                    break;
                default:
                    break;
            }
        }
    }

    public void BakeCurrentCake()
    {
        if (bakeRoutine != null)
            StopCoroutine(bakeRoutine);
        bakeRoutine = StartCoroutine(BakeCake());
    }

    IEnumerator BakeCake()
    {
        bakeTimer = 15;
        while(bakeTimer > 0)
        {
            yield return new WaitForSeconds(1);
            bakeTimer--;
        }
        playerCakeBaked = true;
    }

    public void DeliverCake()
    {
        if(playerCurrentCake != null && currentOrders.Count > 0)
        {
            foreach(Cake cake in currentOrders)
            {
                if(CompareIngredients(playerCurrentCake, cake))
                {
                    moneyEarned += playerCurrentCake.GetCost();
                    deliverCakeText.text = "Cake Delivered!\nYou Got: $" + playerCurrentCake.GetCost() + " On to the Next Cake!";
                    currentOrders.Remove(cake);
                    cakesDelivered++;
                    cakesDeliveredText.text = "Cakes Delivered: " + cakesDelivered;
                    if (cakesDelivered >= 4)
                        win = true;
                    ResetCake();
                    return;
                }
            }
            deliverCakeText.text = "Your Cake Does Not Match Any of the Orders.\nYour Cake Has Been Scrapped\nTry Again!";
            ResetCake();
            return;
        }
        deliverCakeText.text = "Either You Have Not Made a Cake\nOr No Orders Exist\nTry Again!";
        ResetCake();
    }

    public void ResetCake()
    {
        playerCurrentCake = null;
        playerCakeBaked = false;
        if(bakeRoutine != null)
            StopCoroutine(bakeRoutine);
        bakeTimer = 0;
        UpdateCakeOrders();
    }

    public void StartCakeGame()
    {
        StartCoroutine(StartCakeGameOrders());
        StartCoroutine(StartCakeGameTimer());
    }

    IEnumerator StartCakeGameOrders()
    {
        int nextCakeTimer = 30;
        while(true)
        {
            Debug.Log("Generating a new Cake!");
            currentOrders.Add(GenerateCake());
            UpdateCakeOrders();
            while(nextCakeTimer > 0)
            {
                if(currentOrders.Count == 0)
                {
                    break;
                }
                yield return new WaitForSeconds(1);
                nextCakeTimer--;
            }
            if (currentOrders.Count >= 3)
            {
                EndGame();
                break;
            }
            nextCakeTimer = 30;
        }
        yield return null;
    }

    public void UpdateCakeOrders()
    {
        currentOrderText.text = "Current Orders:\n" + GetOrders();
    }

    IEnumerator StartCakeGameTimer()
    {
        while(gameTimer > 0)
        {
            gameTimerText.text = "Time Remaining: " + gameTimer;
            yield return new WaitForSeconds(1);
            if (playerCakeBaked && !ingredientsButtons.activeSelf)
                ingredientsButtons.SetActive(true);
            else if (!playerCakeBaked && ingredientsButtons.activeSelf)
                ingredientsButtons.SetActive(false);
            gameTimer--;
        }
        EndGame();
    }

    Cake GenerateCake()
    {
        Cake cake;
        int random = Random.Range(0, 3);
        if (random == 0)
            cake = new IceCreamCake();
        else if (random == 1)
            cake = new ChocolateCake();
        else
            cake = new VanillaCake();
        // At least one icing layer
        cake = new BaseIcing(cake);
        int ingredientsCount = Random.Range(0, 4);
        for(int i=0;i<ingredientsCount;i++)
        {
            random = Random.Range(0,7);
            switch (random)
            {
                case 0:
                    cake = new BaseIcing(cake);
                    break;
                case 1:
                    cake = new IcingDesigns(cake);
                    break;
                case 2:
                    cake = new BirthdayCandle(cake);
                    break;
                case 3:
                    cake = new PlasticFigurine(cake);
                    break;
                case 4:
                    cake = new PorcelainFigurine(cake);
                    break;
                case 5:
                    cake = new Sprinkles(cake);
                    break;
                case 6:
                    cake = new CrushedCookies(cake);
                    break;
                default:
                    break;
            }
        }
        return cake;
    }

    public string GetOrders()
    {
        string orders = "";
        for(int i=0;i<currentOrders.Count;i++)
        {
            string currentOrder = currentOrders[i].GetIngredients();
            orders += "Order " + (i + 1) + ": " + currentOrder + '\n';
        }
        return orders;
    }

    public void UpdateCurrentCakeText()
    {
        if (playerCurrentCake != null)
            currentCakeText.text = "Current Cake:\n" + playerCurrentCake.GetIngredients();
        else
            currentCakeText.text = "Current Cake:\nNone";
    }

    public bool CompareIngredients(Cake cake1, Cake cake2)
    {
        List<string> ingredientsList1 = cake1.GetIngredients().Split(',').ToList();
        List<string> ingredientsList2 = cake2.GetIngredients().Split(',').ToList();
        ingredientsList1.Sort();
        ingredientsList2.Sort();
        return ingredientsList1.SequenceEqual(ingredientsList2);
    }

    public void EndGame()
    {
        gameOver = true;
        StopAllCoroutines();
        if (win)
            winLossText.text = "You Win!\nYou Delivered " + cakesDelivered + " Cakes and Made $" + moneyEarned;
        else
            winLossText.text = "You Lose!\nToo Many Orders to Handle For You!";
        baseGameUI.SetActive(false);
        gameOverUI.SetActive(true);
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitButton()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
