import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pagamento',
  templateUrl: './pagamento.component.html',
  styleUrls: ['./pagamento.component.css']
})
export class PagamentoComponent implements OnInit {

    public pedido: Pedido;
    public formas: Forma[];
    public formaSelecionada: Forma;

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, route: ActivatedRoute, private router: Router) {
        this.listar(route.snapshot.paramMap.get('id'));
    }

    ngOnInit() {
        this.formas = new Array<Forma>();

        let dinheiro = new Forma();
        dinheiro.id = 0;
        dinheiro.nome = "Dinheiro";
        this.formas.push(dinheiro);

        let credito = new Forma();
        credito.id = 1;
        credito.nome = "Crédito";
        this.formas.push(credito);

        let debito = new Forma();
        debito.id = 2;
        debito.nome = "Débito";
        this.formas.push(debito);

    }

    listar(id) {
        this.http.get<Pedido>(this.baseUrl + 'api/Pedidos/' + id).subscribe(result => {
            this.pedido = result;
            console.log(this.formas);
        }, error => console.error(error));
    }

    pagar() {
        this.pedido.status = 2;
        this.pedido.forma = this.formaSelecionada.id;
        this.http.put<Pedido>(this.baseUrl + 'api/Pedidos/' + this.pedido.id, this.pedido).subscribe(result => {
            this.router.navigate(['/loja']);
        }, error => console.error(error));
    }

}

class Forma {
    id: number;
    nome: string;
}

class Pedido {
    id: number;
    data: string;
    status: number;
    forma: number;
    total: number;
}
