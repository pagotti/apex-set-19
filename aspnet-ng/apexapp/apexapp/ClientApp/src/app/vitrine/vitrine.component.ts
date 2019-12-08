import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vitrine',
  templateUrl: './vitrine.component.html',
  styleUrls: ['./vitrine.component.css']
})
export class VitrineComponent implements OnInit {

    public produtos: Produto[];
    public pedido: Pedido;
    public carrinho: number = 0;

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router:Router) {
        this.listar();
    }

    ngOnInit() {
    }

    listar() {
        this.http.get<Produto[]>(this.baseUrl + 'api/produtos').subscribe(result => {
            this.produtos = result;
        }, error => console.error(error));
    }

    novoPedido(onFinish) {
        if (!this.pedido) {
            this.pedido = new Pedido();
            this.pedido.data = new Date().toISOString();
            this.http.post<Pedido>(this.baseUrl + 'api/pedidos', this.pedido).subscribe(result => {
                this.pedido.id = result.id;
            }, error => console.error(error), () => onFinish());
        } else {
            onFinish();
        }
    }

    novoItemPedido(produto:Produto) {
        let item:ItemPedido = new ItemPedido();
        item.produtoId = produto.id;
        item.pedidoId = this.pedido.id;
        item.quantidade = 1;
        item.preco = produto.preco;
        this.http.post<ItemPedido>(this.baseUrl + 'api/itenspedido', item).subscribe(result => {
            item.id = result.id;
            this.carrinho += 1;
        }, error => console.error(error));
    }

    add(produto) {
        this.novoPedido(() => {
            this.novoItemPedido(produto);
        });
    }

    fechaCarrinho() {
        if (this.pedido) {
            this.pedido.status = 0;
            this.http.put<Pedido>(this.baseUrl + 'api/Pedidos/' + this.pedido.id, this.pedido).subscribe(result => {
                this.router.navigate(['/carrinho', this.pedido.id]);
            }, error => console.error(error));

        }
    }

    chunk(arr, size) {
        var newArr = [];
        for (var i = 0; i < arr.length; i += size) {
            newArr.push(arr.slice(i, i + size));
        }
        return newArr;
    }

}

class Produto {
    id: number;
    nome: string;
    descricao: string;
    preco: number;
}

class Pedido {
    id: number;
    data: string;
    status: number;
    forma: number;
    total: number;
}

class ItemPedido {
    id: number;
    pedidoId: number;
    produtoId: number;
    quantidade: number;
    preco: number;
}
