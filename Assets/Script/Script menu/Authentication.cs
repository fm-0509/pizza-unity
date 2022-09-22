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


    public InputField nomeR;

    public InputField emailR;

    public InputField passwordR;

    public InputField confermaPasswordR;

    public InputField emailL;

    public InputField passwordL;

    private bool flag;

    private string Username;
    private string playfabId;

    void Start() {
        PlayFabAuthService.OnLoginSuccess += OnLoginSuccess;
        PlayFabAuthService.OnPlayFabError += OnPlayFaberror;
    }




    public void apriLogin(){
        loginPanel.SetActive(true);
    }

    public void apriRegister(){
        registerPanel.SetActive(true);
    }

    public void register(){
        PlayFabAuthService.Instance.Email=emailR.text;
        PlayFabAuthService.Instance.Password=passwordR.text;
        PlayFabAuthService.Instance.Username=nomeR.text;
        PlayFabAuthService.Instance.Authenticate(Authtypes.RegisterPlayFabAccount);
        flag=true;
        registerPanel.SetActive(false);
    }

    public void login(){
        PlayFabAuthService.Instance.Email=emailL.text;
        PlayFabAuthService.Instance.Password=passwordL.text;
        PlayFabAuthService.Instance.Authenticate(Authtypes.EmailAndPassword);
        PlayfabManager.IsLoggedIn=true;
        flag=false;
        loginPanel.SetActive(false);
    }

    public void logout(){
        PlayfabManager.IsLoggedIn=false;
        PlayFabAuthenticationAPI.ForgetAllCredentials();
        loginButton.SetActive(true);
        registerButton.SetActive(true);
        logoutButton.SetActive(false);
        flag=false;
        loginPanel.SetActive(false);
    }


    public void backToSelect()
    {
        loginButton.SetActive(true);
        registerButton.SetActive(true);
        logoutButton.SetActive(false);
        loginPanel.SetActive(false);
        registerPanel.SetActive(false);


    }


    public void showLoggedInDetails()
    {
        loginButton.SetActive(false);
        registerButton.SetActive(false);
        registerPanel.SetActive(false);
        logoutButton.SetActive(true);
        loginName.GetComponent<Text>().text = "Logged in as "+this.Username+ " ("+this.playfabId+")";

        
    }

    private void OnDataSuccess(GetAccountInfoResult obj)
    {
        this.Username = obj.AccountInfo.Username;
        this.playfabId = obj.AccountInfo.PlayFabId;
        this.showLoggedInDetails();
        
    }

    private void OnLoginSuccess(PlayFab.ClientModels.LoginResult result)
    {
        Debug.LogFormat("Logged In as: {0}", result.PlayFabId);

        leaderboard.Instance().updateLeaderBoard(); 

        if(flag)
            AddOrUpdateContactEmail(emailR.text);
        else{
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
}
