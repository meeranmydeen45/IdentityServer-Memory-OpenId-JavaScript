var config = {
    authority: "https://localhost:4000/",
    client_id: "Client1",
    redirect_uri: "http://localhost:3000/about",
    response_type: "id_token token",
    scope: "api1.read apione.claims"
};

var userManager = new Oidc.UserManager(config);

var singIn = function () {
    userManager.signinRedirect();
}

userManager.getUser().then(user => {
    console.log("user :", user);
    if (user) {
        console.log(user.access_token)
        axios.defaults.headers.common["Authorization"] = "Bearer " + user.access_token;
    }

})

var callApi = function () {
    axios.get("https://localhost:5000/home/Secret")
        .then(res => {
            console.log(res);
        })
}