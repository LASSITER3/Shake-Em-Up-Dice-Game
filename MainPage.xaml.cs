using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ShakeEmUp
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {

    public int[] myDiceArray = new int[3];
    public int Score = 0;
    public Random RandomGenerator = new Random();

    public MainPage()
    {
      this.InitializeComponent();
      SetupGame();
    }

    private void SetupGame()
    {
      WinText.Text ="Click the \"Shake \'Em Up\" button to play the game";
      ScoreText.Text = $"Your Score is: {Score}";
    }

    //event handler for button click to roll dice
    private void btnRollDice_Click(object sender, RoutedEventArgs e)
    {
      // ValueofDiceText.Text = "Button Clicked";

      for (int i = 0; i < myDiceArray.Length; i++)
      {
        int ValueOfDice = RandomGenerator.Next(1, 7);
        myDiceArray[i] = ValueOfDice;
      }

      ValueofDiceText.Text = $"The value of your Dice roll are: {myDiceArray[0]}, {myDiceArray[1]}, and {myDiceArray[2]}.";

      Dice1.DisplayDiceFace(myDiceArray[0]);
      Dice2.DisplayDiceFace(myDiceArray[1]);
      Dice3.DisplayDiceFace(myDiceArray[2]);

      DiceGameLogic();
    }


    private void DiceGameLogic()
    {
      int newScore = 0;
      string WinMessage = "";

    
      if (myDiceArray[0] == myDiceArray[1] && myDiceArray[0] == myDiceArray[2])
      {
        if (myDiceArray[0] < 6)
        {
          newScore = myDiceArray[0] * 100;
          WinMessage = $"you rolled a {myDiceArray[0]} add {newScore} points!";
        }
        else
        {
          newScore = 1000;
          WinMessage = "Tripple 6's... you just earned a 1000 points!";
        }
      }
      else if (myDiceArray[0] == myDiceArray[1] || myDiceArray[0] == myDiceArray[2] || myDiceArray[1] == myDiceArray[2])
      {
        newScore = 50;
        WinMessage = "You scored 50 points";
      }
      else
      {
        newScore = 0;
        WinMessage = "Sorry.. No matches this roll";
      }
      Score = Score + newScore;
      ScoreText.Text = $"Score: {Score}";
      WinText.Text = WinMessage;

    }
  }
}
