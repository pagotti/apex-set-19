import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-app-usuario',
  templateUrl: './app-usuario.component.html',
  styleUrls: ['./app-usuario.component.css']
})
export class AppUsuarioComponent implements OnInit {

  public usuarios: Usuario[];
  public usuarioAtual: Usuario; 
  public novoUsuario: boolean;
  public cadastro: boolean;
  
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.novo();
    this.listar();
    this.cadastro = false;
  }

  ngOnInit() {
  }

  listar() {
    this.http.get<Usuario[]>(this.baseUrl + 'api/Usuarios').subscribe(result => {
      this.usuarios = result;
      this.cadastro = false;
    }, error => console.error(error));
  }
  
  novo() {
    this.novoUsuario = true;
    this.usuarioAtual = new Usuario();
    this.cadastro = true;
  }

  editar(usuario: Usuario) {
    this.usuarioAtual.id = usuario.id;
    this.usuarioAtual.nome = usuario.nome;
    this.usuarioAtual.idade = usuario.idade;
    this.novoUsuario = false;
    this.cadastro = true;
  }

  excluir(usuario: Usuario) {
    this.http.delete(this.baseUrl + 'api/usuarios/' + usuario.id).subscribe(_ => {
      this.listar();
    });
  }

  salvar() {
    if (this.novoUsuario) {
      this.http.post(this.baseUrl + 'api/usuarios', this.usuarioAtual).subscribe(_ => this.listar());
    } else {
      this.http.put(this.baseUrl + 'api/usuarios/' + this.usuarioAtual.id, this.usuarioAtual).subscribe(_ => this.listar());
    }
  }

}

class Usuario {
  id: number;
  nome: string;
  idade: number;
}
