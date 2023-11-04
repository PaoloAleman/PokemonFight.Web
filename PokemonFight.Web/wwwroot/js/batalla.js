const ataquesPokemones = document.getElementsByName("ataquePokemon");

ataquesPokemones.forEach(ap => {
    ap.addEventListener("click", () => {
        conn.invoke("atacarPokemon", ap.value).catch(function (err) {
            return console.error(err.toString());
        });
    });
});

conn.on("atacado", function (daño, pokemonAtacado) {
    var vida = document.getElementById(pokemonAtacado);
    if(parseInt(vida.textContent) - parseInt(daño) > 0) {
        vida.textContent = parseInt(vida.textContent) - parseInt(daño);
    } else {
        vida.textContent = 0;
    }
});