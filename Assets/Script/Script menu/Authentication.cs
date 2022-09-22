using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Authentication : MonoBehaviour
{
    [SerializeField] private GameObject loginPanel;

    [SerializeField] private GameObject registerPanel;

    [SerializeField] private GameObject loginButton;

    [SerializeField] private GameObject registerButton;

    [SerializeField] private GameObject logoutButton;

    [SerializeField] private GameObject loginName;

    [SerializeField] private GameObject errore;

    [SerializeField] private GameObject Errorino2;


    [SerializeField] private static GameObject Errorino;



    public Text topText;

    public Text yourScore;

    public InputField nomeR;

    public InputField emailR;

    public InputField passwordR;

    public InputField confermaPasswordR;

    public InputField emailL;

    public InputField passwordL;

    private bool flag;

    private string Username;
    private string playfabId;

    void Start()
    {
        Errorino=Errorino2;
        PlayFabAuthService.OnLoginSuccess += OnLoginSuccess;
        PlayFabAuthService.OnPlayFabError += OnPlayFaberror;
        if(PlayfabManager.IsLoggedIn){
            loginButton.SetActive(false);
            registerButton.SetActive(false);
            logoutButton.SetActive(true);
            loginName.SetActive(true);
        }
    }




    public void apriLogin()
    {
        loginPanel.SetActive(true);
    }

    public void apriRegister()
    {
        registerPanel.SetActive(true);
    }

    public void register()
    {
        if (passwordR.text == confermaPasswordR.text)
        {
            PlayFabAuthService.Instance.Email = emailR.text;
            PlayFabAuthService.Instance.Password = passwordR.text;
            PlayFabAuthService.Instance.Username = nomeR.text;
            PlayFabAuthService.Instance.Authenticate(Authtypes.RegisterPlayFabAccount);
            flag = true;
            registerPanel.SetActive(false);
            errore.SetActive(false);
        }
        else{
            errore.SetActive(true);
        }
    }

    private void OnError(PlayFabError obj)
    {
        throw new NotImplementedException();
    }

    private void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult obj)
    {
        Debug.Log("Update name!");
    }

    public void login()
    {
        PlayFabAuthService.Instance.Email = emailL.text;
        PlayFabAuthService.Instance.Password = passwordL.text;
        PlayFabAuthService.Instance.Authenticate(Authtypes.EmailAndPassword);
        PlayfabManager.IsLoggedIn = true;
        flag = false;
        loginPanel.SetActive(false);
    }

    public void logout()
    {
        PlayfabManager.IsLoggedIn = false;
        PlayFabAuthenticationAPI.ForgetAllCredentials();
        PlayFabClientAPI.ForgetAllCredentials();
        loginButton.SetActive(true);
        registerButton.SetActive(true);
        logoutButton.SetActive(false);
        flag = false;
        loginPanel.SetActive(false);
        loginName.SetActive(false);
    }


    public void backToSelect()
    {
        loginButton.SetActive(true);
        registerButton.SetActive(true);
        logoutButton.SetActive(false);
        loginPanel.SetActive(false);
        registerPanel.SetActive(false);
        errore.SetActive(false);
        Errorino.SetActive(false);
    }


    private void OnDataSuccess(GetAccountInfoResult obj)
    {
        loginName.GetComponent<Text>().text = "Logged in as " + obj.AccountInfo.Username;
        loginButton.SetActive(false);
        registerButton.SetActive(false);
        registerPanel.SetActive(false);
        logoutButton.SetActive(true);
    }

    private void OnLoginSuccess(PlayFab.ClientModels.LoginResult result)
    {
        Debug.LogFormat("Logged In as: {0}", result.PlayFabId);

        leaderboard.Instance().updateLeaderBoard(topText, yourScore);

        if (flag)
        {
            AddOrUpdateContactEmail(emailR.text);
            PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest { DisplayName = nomeR.text, }, OnDisplayNameUpdate, OnError);
        }
        else
        {
            loginButton.SetActive(false);
            registerButton.SetActive(false);
            logoutButton.SetActive(true);
        }

        PlayFabClientAPI.GetAccountInfo(
            new GetAccountInfoRequest(), OnDataSuccess, OnPlayFaberror);

    }

    /// <summary>
    /// Error handling for when Login returns errors.
    /// </summary>
    /// <param name="error"></param>
    private void OnPlayFaberror(PlayFabError error)
    {
        Debug.Log(error.Error);
        Debug.LogError(error.GenerateErrorReport());
    }

    void AddOrUpdateContactEmail(string emailAddress)
    {
        var request = new AddOrUpdateContactEmailRequest
        {
            EmailAddress = emailAddress
        };
        PlayFabClientAPI.AddOrUpdateContactEmail(request, result =>
        {
            Debug.Log("The player's account has been updated with a contact email");
        }, OnPlayFaberror);
    }

    public static void erroreText(){
        Errorino.SetActive(true);
    }
}
