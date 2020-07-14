var app = new Vue({
    el: '#app',
    data:
    {
        Carregado: false,
        loading: false,
        objectIndex: 0,
        DoaçãoModel: {
            Id: 0,
            Valor: 4.99
        },
        doação: [],
    },
    mounted() {
    },
    methods: {
        createDoação() {
            this.loading = true;
            axios.post('/Doação/doação', this.DoaçãoModel)
                .then(res => {
                    console.log(res.data);
                    this.doação.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.Carregado = true;
                    this.loading = false;
                });
        },
        newDoação() {
            this.Carregado = true;
            this.DoaçãoModel.Id = 0;
        },
    },
    computed: {
    },
});