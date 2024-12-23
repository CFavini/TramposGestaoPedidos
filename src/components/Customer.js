import React, { useState, useEffect } from 'react';
import api from '../services/api';

const Customer = () => {
    const [customers, setCustomers] = useState([]);
    const [form, setForm] = useState({ name: '', email: '', phone: '' });

    // Função para carregar os clientes
    const fetchCustomers = async () => {
        try {
            const response = await api.get('/Customer');
            setCustomers(response.data);
        } catch (error) {
            console.error('Erro ao buscar clientes:', error);
        }
    };

    // Função para criar um cliente
    const createCustomer = async () => {
        try {
            await api.post('/Customer', form);
            fetchCustomers(); // Atualiza a lista
            setForm({ name: '', email: '', phone: '' }); // Limpa o formulário
        } catch (error) {
            console.error('Erro ao criar cliente:', error);
        }
    };

    // Carrega os clientes ao carregar o componente
    useEffect(() => {
        fetchCustomers();
    }, []);

    return (
        <div>
            <h1>Clientes</h1>
            <form
                onSubmit={(e) => {
                    e.preventDefault();
                    createCustomer();
                }}
            >
                <div>
                    <label>Nome:</label>
                    <input
                        type="text"
                        placeholder="Nome"
                        value={form.name}
                        onChange={(e) => setForm({ ...form, name: e.target.value })}
                    />
                </div>
                <div>
                    <label>Email:</label>
                    <input
                        type="email"
                        placeholder="Email"
                        value={form.email}
                        onChange={(e) => setForm({ ...form, email: e.target.value })}
                    />
                </div>
                <div>
                    <label>Telefone:</label>
                    <input
                        type="text"
                        placeholder="Telefone"
                        value={form.phone}
                        onChange={(e) => setForm({ ...form, phone: e.target.value })}
                    />
                </div>
                <button type="submit">Adicionar Cliente</button>
            </form>

            <h2>Lista de Clientes</h2>
            <ul>
                {customers.map((customer) => (
                    <li key={customer.id}>
                        {customer.name} - {customer.email} - {customer.phone}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Customer;
