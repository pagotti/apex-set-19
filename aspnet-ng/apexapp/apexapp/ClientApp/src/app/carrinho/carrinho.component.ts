import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-carrinho',
  templateUrl: './carrinho.component.html',
  styleUrls: ['./carrinho.component.css']
})
export class CarrinhoComponent implements OnInit {

    public carrinho: Pedido;

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, route: ActivatedRoute, private router: Router) {
        this.listar(route.snapshot.paramMap.get('id'));
    }

    ngOnInit() {
    }

    listar(pedido) {
        this.http.get<Pedido>(this.baseUrl + 'api/Pedidos/' + pedido + '/Itens').subscribe(result => {
            this.carrinho = result;
        }, error => console.error(error));
    }

    excluir(item: ItemPedido) {
        this.http.delete<ItemPedido>(this.baseUrl + 'api/ItensPedido/' + item.id).subscribe(result => {
            this.listar(this.carrinho.id);
        }, error => console.error(error));

    }

    pagar() {
        this.carrinho.status = 1;
        this.http.put<Pedido>(this.baseUrl + 'api/Pedidos/' + this.carrinho.id, this.carrinho).subscribe(result => {
            this.router.navigate(['/pagamento', this.carrinho.id]);
        }, error => console.error(error));
    }

}

class Pedido {
    id: number;
    data: string;
    status: number;
    forma: number;
    total: number;
    itens: ItemPedido[];
}

class Produto {
    id: number;
    nome: string;
}

class ItemPedido {
    id: number;
    pedidoId: number;
    produtoId: number;
    produto: Produto;
    quantidade: number;
    preco: number;
}
