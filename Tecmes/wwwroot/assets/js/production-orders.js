import $ from 'jquery';
import DataTable from 'datatables.net-dt';
import 'datatables.net-responsive-dt';
import { apiGet, getJwtToken } from './api';

$(document).ready(async () => {
    const token = getJwtToken();
    if (!token) {
        alert('Acesso expirado!');
    }
    try {
        const response = await apiGet('production/orders');
        createTable();
    } catch (err) {
        console.log(err);
    }
});

function createTable() {
    const data = [
        [1, 'Teste', 12, 12, 12]
    ]
    new DataTable('#production-orders-table', {
        data,
        columns: [
            { title: 'Id' },
            { title: 'Produto' },
            { title: 'Quantidade' },
            { title: 'Produzido' },
            { title: 'Vendido' }
        ]
    });
}

