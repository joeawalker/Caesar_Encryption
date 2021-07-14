using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EncryptionTestUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void userInput_TextChanged(object sender, TextChangedEventArgs e)
        {
   
        }

        //Function used to encrypt a string
        public string encrypt(string encString)
        {
            List<string> alp = new List<string>(new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " " }); 
            int len = encString.Length;
            encString = encString.ToLower();
            String enc = "";

            for (int y=0; y<=len-1; y++) //For length of the string to encrypt
                for (int i=0; i<=alp.Count-1; i++) //For length of alphabet
                    if (alp[i] == "z" && encString[y].ToString() == alp[alp.Count-2]) //If the letter 'z' is found
                    {
                        enc += alp[0]; //Use first letter in alphabet
                    }
                    else if (alp[i] == " " && encString[y].ToString() == alp[alp.Count-1]) //If a space is found
                    {
                        Random rnd = new Random();
                        int num = rnd.Next(1, 9);
                        enc += num.ToString(); //Use a random number
                    }
                    else if (encString[y].ToString() == alp[i]) //If just a normal letter
                                    {
                                        enc += alp[i + 1]; //Shift 1 letter up
                                    }
            return enc;
        }

        //Function used to decrypt a string
        public string decrypt(string decString)
        {
            List<string> alp = new List<string>(new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " " });
            int len = decString.Length;
            decString = decString.ToLower();
            String dec = "";

            for (int y = 0; y <= len - 1; y++) //For length of the string to encrypt
                for (int i = 0; i <= alp.Count - 1; i++) //For length of alphabet
                    if (alp[i] == "a" && decString[y].ToString() == alp[0]) //If the letter 'a' is found
                    {
                        dec += alp[alp.Count - 2]; //Use the last letter in the alphabet
                    }
                    else if (Char.IsNumber(decString, y)==true && alp[i]==" ") //If the character is a number
                    {
                        dec += " "; //Change to a space
                    }
                    else if (decString[y].ToString() == alp[i]) //If just a normal letter
                    {
                        dec += alp[i - 1]; //Shift 1 letter down
                    }
            return dec;
        }

        //Assigns functions to button presses
        private void encBtn_Click(object sender, RoutedEventArgs e)
        {
            //Gets users input and passes it through the encryption
            string encText = userInput.Text;
            encText = encrypt(encText);
            encString.Text = encText;

            //Gets the encrypted text and passes it through the decryption
            string decText = userInput2.Text;
            decText = decrypt(decText);
            decString.Text = decText;

        }

        //Copies over the encrypted text into the decryption input box for ease
        private void copyBtn_Click(object sender, RoutedEventArgs e)
        {
            userInput2.Text = encString.Text;
        }
    }
}
