'use strict'

const url = 'https://jsonplaceholder.typicode.com/users'
const content = document.querySelector('tbody')
let template = ''

//crea un modal con boostrap
const myModal = new bootstrap.Modal(document.getElementById('exampleModal'))
//capturando datos
const form = document.querySelector('form')
const nombre = document.querySelector('#nombre')
const username = document.querySelector('#username')
const email = document.querySelector('#email')
const btnCrear = document.querySelector('#btnCrear')
const advice = document.querySelector('span')
const enviar = document.querySelector('#send')

advice.style.display = 'none'

let option = ''
//Crear usuario
btnCrear.addEventListener('click', (e) => {
    clear()
    myModal.show()
    option = 'crear'
    console.log("btnCrear presionado")
})


//clear
const clear = () => {
    nombre.value = ''
    username.value = ''
    email.value = ''
    advice.style.display = 'none'
}

//Procedimiento de como mostrar los registro, consumiendo API:
const loadResults = async () => {
    try {
        const response = await fetch(url)
        const data = await response.json()
        return data

    } catch (err) {
        console.log(err)

    }
}

//enviar resultados del modal
const postUsers = async () => {
    try {
        const body = {
            method: 'POST',
            body: JSON.stringify({
                name: nombre.value,
                email: email.value,
                username: username.value
            }),
            headers: {
                'Accept': "application/json",
                'Content-type': "application/json"
            }
        }

        const response = await fetch(url, body)
        const data = await response.json()
        console.log(data)
        let user = new Array()
        user.push(data)
        showResults(user)

    } catch (err) {
        console.log(err)
    }
}

//Borrar con api propia:
//const deleteUsers = async (id) => {
//     try {
//         const body = {
//             method: "DELETE",
//             body: JSON.stringify({
//                 id: id
//             }),
//             headers: {
//                 'Accept': "application/json",
//                 'Content-type': "application/json"
//             }
//         }

//         const response = await fetch(`${url}/${id}`, body)
//         const data = response.json()
//         console.log(data)

//     } catch (err) {
//         console.log(err)
//     }
// }

//Listar usuarios:
const showResults = (results) => {
    results.map(user => {
        template += `
                        <tr class="text-center">
                            <td>${user.id}</td>
                            <td>${user.name}</td>
                            <td>${user.email}</td>
                            <td>${user.username}</td>
                            <td><a class="btnEditar btn btn-warning">Editar</a> <a class="btnBorrar btn btn-danger">Borrar<a/></td>
                        </tr>
                    `

    })
    content.innerHTML = template
}

//GET
loadResults()
    .then(data => showResults(data))
    .catch(err => console.log(err))


//Emulando metodo on jQuery para acceder a los botones
const on = (element, event, selector, handler) => {
    element.addEventListener(event, e => {
        //toma el target mas cercano al selector o el mismo selector
        if (e.target.closest(selector)) {
            handler(e)
        }
    })
}

//DELETE
const deleteUsers = async (id) => {
    try {
        const config = {
            method: 'DELETE'
        }

        const response = await fetch(`${url}/${id}`, config)
        console.log(response)

    } catch (err) {
        console.log(err)
    }
}

//Procedimiento borrar
on(document, 'click', '.btnBorrar', (e) => {
    //forma 1 de capturar id en una tabla
    const fila = e.target.parentNode.parentNode
    const id = fila.firstElementChild.innerHTML
    //Borrar con Api publica:
    deleteUsers(id)
})

//Procediento editar
let idFrom = 0
on(document, 'click', '.btnEditar', e => {
    //forma 2 de capturar id en una tabla
    const fila = e.target.parentNode.parentNode

    idFrom = fila.children[0].innerHTML
    const nombreUpdate = fila.children[1].innerHTML
    const emailUpdate = fila.children[2].innerHTML
    const usernameUpdate = fila.children[3].innerHTML

    nombre.value = nombreUpdate
    email.value = emailUpdate
    username.value = usernameUpdate
    option = 'editar'
    console.log(option)
    myModal.show()

    console.log(idFrom, nombreUpdate, emailUpdate, usernameUpdate)
})

//PUT
const updateUser = async (id) => {
    try {
        const body = {
            method: 'PUT',
            body: JSON.stringify({
                name: nombre.value,
                email: email.value,
                username: username.value
            }),
            headers: {
                'Accept': "application/json",
                'Content-type': "application/json"
            }
        }

        const response = await fetch(`${url}/${id}`, body)
        const data = await response.json()
        myModal.hide()
        console.log(data)

    } catch (err) {
        console.log(err)
    }
}

//Evento de formulario
enviar.addEventListener('click', e => {
    e.preventDefault()
    console.log("submit realizado")
    if (option == 'crear') {
        if (nombre.value != '' || email.value != '' || username.value != '') {
            postUsers()
            myModal.hide()
            console.log("opcion crear")
        } else {
            advice.style.display = 'block'
        }
    }

    if (option == 'editar') {
        updateUser(idFrom)
    }

})