const ataquesPokemones = document.getElementsByName("ataquePokemon");
const chat = document.getElementById("chat");

ataquesPokemones.forEach(ap => {
    ap.addEventListener("click", () => {
        conn.invoke("atacarPokemon", ap.value).catch(function (err) {
            return console.error(err.toString());
        });
    });
});

conn.on("atacado", function (daño, pokemonAtacado,pokemonAtacante,vidaPokemon, mensaje) {

    var vida = document.getElementById(pokemonAtacado);
    var barraVida = document.getElementById("barraVida " + pokemonAtacado);

    console.log("ataque recibido", mensaje);

    if(parseFloat(vida.textContent) - parseFloat(daño) > 0) {
        vida.textContent = parseFloat(vida.textContent) - parseFloat(daño);

        barraVida.classList.remove("w-[100%]");

        var porcentajeVida = vidaPokemon * (parseFloat(vida.textContent)) / 100;

        barraVida.classList.add("w-["+porcentajeVida+"%]");
    } else {
        vida.textContent = 0;
        barraVida.classList.add("w-[0%]");

        var data = { ganador: pokemonAtacante }
        var url = "/Pokemon/definirGanador"
        $.post(url, data).done(function (data) {
            window.location.href = "/Pokemon/ganador";
        })   
    }
    const mensajeElemento = document.createElement("li");
    mensajeElemento.textContent = `${mensaje.usuario} atacó a ${pokemonAtacado} con ${mensaje.habilidad} y causó ${mensaje.danio} de daño.`;
    chat.appendChild(mensajeElemento);

    chat.scrollTop = chat.scrollHeight;
});
