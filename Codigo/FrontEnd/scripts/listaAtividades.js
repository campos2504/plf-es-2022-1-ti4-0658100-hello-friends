const baseURLOpcaoCerta = `https://tishellofriends.azurewebsites.net/api/opcaocerta`;
let idModuloEscolhidoOC;

var selecaoAtividade = {
  opcaoCerta(event) {
    let nameOfFunction = [event.target];
    console.log(nameOfFunction);
    let arg1 = event.target.getAttribute('id');

    localStorage.setItem('atividadeOpcaoCerta', JSON.stringify({ arg1 }));
  }
}

let moduloEscolhido_opcaoCerta = JSON.parse(localStorage.getItem('moduloCorrente'));
idModuloEscolhidoOC = moduloEscolhido_opcaoCerta.event;


//Exclui Atividade Opção certa
function deletaAtividadeOpcaoCerta(id) {

  console.log("id->", id);
  let urlDeleteOpcaoCerta = ''.concat(baseURLOpcaoCerta, '/', id);

  fetch(urlDeleteOpcaoCerta, {
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
    method: 'delete',
  }).then(function (res) {
    console.log("reposta delete->", res)
    window.location.reload();
  })
    .catch(function (res) { console.log("reposta delete->", res) })
};


function table() {
  fetch(baseURLOpcaoCerta, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
  }).then(result => result.json())
    .then((data) => {
      let dadosModuloAlunoOpcaoCerta;
      if(ehAluno()){
        dadosModuloAlunoOpcaoCerta = getModuloAlunoOpcaoCerta();
      }
      let nota;
      //process the returned data
      let divTela = document.querySelector('#data-table #listaAtividades_opcaoCerta');
      let texto = "";
      // Montar texto HTML das atividades
      for (i = 0; i < data.length; i++) {
        if (data[i].moduloId == idModuloEscolhidoOC) {
          nota  = undefined;
          if(ehAluno()){
            dadosModuloAlunoOpcaoCerta.forEach(element => {
              if(element.opcaoCertaID == data[i].id){
                nota = (element.resultado * 100) + "%";
              }
            });
          }          
          if(nota == undefined){
            nota = "Pendente";
          } 
          texto = texto + ` 
                        <tr id="tb">
                            <td id="tb">
                            <a onclick="selecaoAtividade.opcaoCerta(event)" href="AtividadeDoAluno.html">
                                <i id="${data[i].id}"">
                                    ${data[i].titulo}
                                </i>                              
                                </a>
                            </td> 
                            <td>
                            <button type="button" style=${ehAluno() ? 'display:none;' : ""} id="btn_editar" onclick="editarAtividade.editar(${data[i].id})" data-toggle="modal"
                              data-target="#modalEdicaoModulo" class="btn btn-light btn-circle btn-sm">
                              <svg width="2em" height="2em" viewBox="0 0 16 16" class="bi bi-pencil editar-excluir"
                                  fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                  <path fill-rule="evenodd"
                                      d="M12.146.146a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1 0 .708l-10 10a.5.5 0 0 1-.168.11l-5 2a.5.5 0 0 1-.65-.65l2-5a.5.5 0 0 1 .11-.168l10-10zM11.207 2.5L13.5 4.793 14.793 3.5 12.5 1.207 11.207 2.5zm1.586 3L10.5 3.207 4 9.707V10h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.293l6.5-6.5zm-9.761 5.175l-.106.106-1.528 3.821 3.821-1.528.106-.106A.5.5 0 0 1 5 12.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.468-.325z" />
                              </svg>
                            </button>
                            <button type="button" style=${ehAluno() ? 'display:none;' : ""} id="btn_excluir" onclick="deletaAtividadeOpcaoCerta('${data[i].id}')"
                              class="btn btn-light btn-circle btn-sm">
                              <svg width="3em" height="3em" viewBox="0 0 16 16" class="bi bi-x editar-excluir"
                                  fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                  <path fill-rule="evenodd"
                                      d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z" />
                              </svg>
                             </button>
                        </td>
                        <td>
                              <div class=">
                                <h3 class=""><span id=""></span>${nota}</h3>
                              </div>
                           </td>                         
                        </tr>
                    `;
        }
      };

      // Preencher a DIV com o texto HTML
      divTela.innerHTML = texto;
    })
}
table();