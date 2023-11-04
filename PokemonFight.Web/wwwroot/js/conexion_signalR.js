var conn = new signalR.HubConnectionBuilder().withUrl("/pokemonHub").build();

conn.start().then(function () {
    console.log("conectado");
});

