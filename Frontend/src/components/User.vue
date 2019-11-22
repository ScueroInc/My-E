<template>
    <v-layout align-start>
        <v-flex>
            <v-toolbar flat color="white">
                <v-toolbar-title>Users</v-toolbar-title>
                    <v-divider
                    class="mx-2"
                    inset
                    vertical
                    ></v-divider>
                    <v-spacer></v-spacer>
                    <v-text-field class="text-xs-center" v-model="search" append-icon="search" label="Búsqueda" single-line hide-details></v-text-field>
                    <v-spacer></v-spacer>
                    <v-dialog v-model="dialog" max-width="500px">
                        <v-btn slot="activator" color="primary" dark class="mb-2">Nuevo</v-btn>
                        <v-card>
                            <v-card-title>
                            <span class="headline">{{ formTitle }}</span>
                            </v-card-title>
                
                            <v-card-text>
                            <v-container grid-list-md>
                                <v-layout wrap>
                                <v-flex xs12 sm6 md6>
                                    <v-text-field v-model="name" label="Name">
                                    </v-text-field>
                                </v-flex>
                                <v-flex xs12 sm6 md6>
                                    <v-select v-model="Idrol"
                                    :items="roles" label="Rol">
                                    </v-select>
                                </v-flex>
                                <v-flex xs12 sm6 md6>
                                    <v-select v-model="typedocument"
                                    :items="documentos" label="typedocument">
                                    </v-select>
                                </v-flex>
                                <v-flex xs12 sm6 md6>
                                    <v-text-field v-model="documentnumber" label="Number Document">
                                    </v-text-field>
                                </v-flex>
                                <v-flex xs12 sm6 md6>
                                    <v-text-field v-model="address" label="Address">
                                    </v-text-field>
                                </v-flex>
                                <v-flex xs12 sm6 md6>
                                    <v-text-field v-model="phone" label="Phone">
                                    </v-text-field>
                                </v-flex>
                                <v-flex xs12 sm6 md6>
                                    <v-text-field v-model="email" label="Email">
                                    </v-text-field>
                                </v-flex>
                                <v-flex xs12 sm6 md6>
                                    <v-text-field type="password" v-model="password" label="Password">
                                    </v-text-field>
                                </v-flex>
                
                                </v-layout>
                            </v-container>
                            </v-card-text>
                
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-btn color="blue darken-1" flat @click.native="close">Cancelar</v-btn>
                                <v-btn color="blue darken-1" flat @click.native="guardar">Guardar</v-btn>
                            </v-card-actions>
                        </v-card>
                    </v-dialog>
                </v-toolbar>
           <v-data-table :headers="headers" :items="usuarios" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
                    </td>
                    <td>{{ props.item.name }}</td>
                    <td>{{ props.item.rol }}</td>
                    <td>{{ props.item.typedocument }}</td>
                    <td>{{ props.item.documentnumber }}</td>
                    <td>{{ props.item.address }}</td>
                    <td>{{ props.item.phone }}</td>
                    <td>{{ props.item.email }}</td>
                
                </template>
                <template slot="no-data">
                <v-btn color="primary" @click="listar">Resetear</v-btn>
                </template>
            </v-data-table>
        </v-flex>
    </v-layout>
</template>
<script>
    import axios from 'axios'
    export default {
        data(){
            return {
                usuarios:[],                
                dialog: false,
                headers: [
                    { text: 'Opciones', value: 'opciones', sortable: false },
                    { text: 'Name', value: 'name' },
                    { text: 'Rol', value: 'rol' },
                    { text: 'TypeDocument', value: 'typedocument' },
                    { text: 'DocumentNumber', value: 'documentnumber', sortable: false  },
                    { text: 'Address', value: 'address', sortable: false  },
                    { text: 'Phone', value: 'phone', sortable: false  },
                    { text: 'Email', value: 'email', sortable: false  },
                               
                ],
                search: '',
                editedIndex: -1,
                id: '',
                idrol:'',
                roles:[                   
                ],
                nombre:'',
                tipo_documento: '',
                documentos: ['DNI','RUC','PASAPORTE','CEDULA'],
                num_documento: '',
                direccion: '',
                telefono: '',
                email: '',
                password:'',
                actPassword:false,
                passwordAnt:'',
                valida: 0,
                validaMensaje:[],
                adModal: 0,
                adAccion: 0,
                adNombre: '',
                adId: ''             
            }
        },
        computed: {
            formTitle () {
                return this.editedIndex === -1 ? 'Nuevo user' : 'Actualizar user'
            }
        },

        watch: {
            dialog (val) {
            val || this.close()
            }
        },

        created () {
            this.listar();
            this.select();
        },
        methods:{
            listar(){
                let me=this;
                axios.get("api/user").then(function(response){
                    //console.log(response);
                    me.users=response.data;
                }).catch(function(error){
                    console.log(error);
                });
            },
            select(){
                let me=this;
                var rolesArray=[];
                axios.get("api/rol").then(function(response){
                    rolesArray=response.data;
                    rolesArray.map(function(x){
                        me.roles.push({text: x.name,value:x.idrol});
                    });
                }).catch(function(error){
                    console.log(error);
                });
            },
            editItem (item) {
                this.id=item.iduser;
                this.idrol=item.idrol;
                this.name=item.name;
                this.typedocument=item.typedocument;
                this.documentnumber=item.documentnumber;
                this.address=item.address;
                this.phone=item.phone;
                this.email=item.email;
                this.password=item.passwordhash;
                this.passwordAnt=item.passwordhash;
                this.editedIndex=1;
                this.dialog = true
            },
            close () {
                this.dialog = false;
                this.limpiar();
            },
            limpiar(){
                this.id="";
                this.idrol="";
                this.name="";
                this.typedocument="";
                this.documentnumber="";
                this.address="";
                this.phone="";
                this.email="";
                this.password="";
                this.passwordAnt="";
                this.actPassword=false;
                this.editedIndex=-1;
            },
            guardar () {
                if (this.validar()){
                    return;
                }
                if (this.editedIndex > -1) {
                    //Código para editar
                    //Código para guardar
                    let me=this;
                    if (me.password!=me.passwordAnt){
                        me.actPassword=true;
                    }
                    axios.put("api/user",{
                        'iduser':me.id,
                        'idrol':me.idrol,
                        'name':me.nombre,
                        'typedocument': me.typedocument,
                        'documentnumber':me.documentnumber,
                        'address':me.address,
                        'phone': me.phone,
                        'email':me.email,
                        'password':me.password,
                        'act_password':me.actPassword                        
                    }).then(function(response){
                        me.close();
                        me.listar();
                        me.limpiar();                        
                    }).catch(function(error){
                        console.log(error);
                    });
                } else {
                    //Código para guardar
                    let me=this;
                    axios.post("api/user",{
                        'idrol':me.idrol,
                        'name':me.nombre,
                        'typedocument': me.typedocument,
                        'documentnumber':me.documentnumber,
                        'address':me.address,
                        'phone': me.phone,
                        'email':me.email,
                        'password':me.password
                    }).then(function(response){
                        me.close();
                        me.listar();
                        me.limpiar();                        
                    }).catch(function(error){
                        console.log(error);
                    });
                }
            },
           
        }        
    }
</script>
