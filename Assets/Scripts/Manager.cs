using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{
    public TMP_InputField nameIN;
    public TMP_InputField emailIN;
    public TMP_InputField passwortIN;
    public TMP_InputField wiederholenIN;

    public string name;
    public string email;
    public string passwort;
    public string wiederholen;

    public TMP_Text fehlerIN;

    public void Submit()
    {
        name = nameIN.text;
        email = emailIN.text;
        passwort = passwortIN.text;
        wiederholen = wiederholenIN.text;

        

        if (!Regex.IsMatch(name, @"^[A-Z���][a-z����]+(\s[A-Z���][a-z����]+)?$"))
        {
            fehlerIN.text  = " Bitte gib einen g�ltigen Namen ein.";
            return;
        }

        if (!Regex.IsMatch(email, @"^[\w\.-]+@[\w\.-]+\.\w{2,}$"))
        {
            fehlerIN.text = " Ung�ltige E-Mail-Adresse.";
            return;
        }

        if (!Regex.IsMatch(passwort, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{8,}$"))
        {
            fehlerIN.text = " Passwort zu schwach (min. 8 Zeichen, Gro�-/Kleinbuchstaben, Zahl, Sonderzeichen).";
            return;
        }

        if (passwort != wiederholen)
        {
            fehlerIN.text = " Passw�rter stimmen nicht �berein.";
            return;
        }

        SceneManager.LoadScene("Done");

    }
}
