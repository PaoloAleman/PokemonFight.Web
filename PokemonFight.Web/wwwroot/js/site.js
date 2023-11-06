const pokemonesElegidos = document.getElementsByName("pokemonElegido");
var pokemones = [];

conn.on("pokemonEnviado", function (pokemon) {
    pokemonesElegidos.forEach(p => {
        if (p.value == pokemon) {
            p.disabled = true;
            p.classList.remove("border-black");
            p.classList.add("border-[#dd7409]", "border-4");
        }
    });

    pokemones.push(pokemon);

    if (pokemones.length == 2) {
        conn.invoke("redirigir", pokemones).catch(function (err) {
            return console.error(err.toString());
        });
        console.log(pokemones.length);
    }
});


conn.on("redireccion", function (pokemonesObtenidos) {
    var data = { nombre: pokemonesObtenidos[0], nombre2: pokemonesObtenidos[1] }
    var url = "/Pokemon/batalla"
    $.post(url, data).done(function (data) {
        window.location.href = "/Pokemon/batallas";
    })
});

var selecciono = false;
pokemonesElegidos.forEach(p => {
    p.addEventListener("click", () => {
        
        if (!selecciono) {
            selecciono = true;
            conn.invoke("enviarPokemon", p.value).catch(function (err) {
            return console.error(err.toString());
            });
            
        }
        
    });
});


