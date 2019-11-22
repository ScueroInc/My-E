<template>
  <v-app id="app">
    <v-navigation-drawer
      fixed
      :clipped="$vuetify.breakpoint.mdAndUp"
      app
      v-model="drawer"
    >
      <v-list dense>
        <template>
          <v-list-tile :to="{name:'home'}">
            <v-list-tile-action>
              <v-icon>home</v-icon>
            </v-list-tile-action>
            <v-list-tile-title>
              Inicio
            </v-list-tile-title>
          </v-list-tile>
        </template>

        <template>
          <v-list-group>
            <v-list-tile slot="activator">
              <v-list-tile-content>
                <v-list-tile-title>
                  Pedido
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            <v-list-tile :to="{ name: 'orders'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Orders
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            <v-list-tile :to="{ name: 'medicalequipments'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  MedicalEquipments
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            
          </v-list-group>
        </template>

        <template>
          <v-list-group>
            <v-list-tile slot="activator">
              <v-list-tile-content>
                <v-list-tile-title>
                  Revision
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            <v-list-tile :to="{ name: 'schedules'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Schedules
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            <v-list-tile :to="{ name: 'machinereviews'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  MachineReviews
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            
          </v-list-group>
        </template>

        <template>
          <v-list-group>
            <v-list-tile slot="activator">
              <v-list-tile-content>
                <v-list-tile-title>
                  Reporte
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            <v-list-tile :to="{ name: 'finalreports'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  FinalReports
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>


            
          </v-list-group>
        </template>

         <template>
          <v-list-group>
            <v-list-tile slot="activator">
              <v-list-tile-content>
                <v-list-tile-title>
                  Accesos
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            <v-list-tile :to="{ name: 'roles'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Roles
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            <v-list-tile :to="{ name: 'users'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Users
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            
          </v-list-group>
        </template>
        

      </v-list>
    </v-navigation-drawer>
    <v-toolbar
      color="blue darken-3"
      dark
      app
      :clipped-left="$vuetify.breakpoint.mdAndUp"
      fixed
    >
      <v-toolbar-title style="width: 300px" class="ml-0 pl-3">
        <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
        <span class="hidden-sm-and-down">VierArsTF</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn icon>
        <v-icon>apps</v-icon>
      </v-btn>
    </v-toolbar>
    <v-content>
      <v-container fluid fill-height>
        <v-slide-y-transition mode="out-in">
          <router-view/>
        </v-slide-y-transition>
      </v-container>
    </v-content>
    <v-footer dark height="auto">
      <v-layout justify-center>
        <v-flex text-xs-center>
          <v-card flat tile color="primary" class="white--text">
            <v-card-text class="white--text pt-0">
             HAMP &copy;2019
            </v-card-text>
          </v-card>
        </v-flex>
      </v-layout>
    </v-footer>

  </v-app>
</template>


<script>

export default {
  name: 'App',
  data () {
    return {
      drawer: true,
     }
  },
   computed:{
    logueado(){
      return this.$store.state.user;
    },
    esAdministrador(){
      return this.$store.state.user && this.$store.state.user.rol == 'Administrator';
    },
    esReciclador(){
      return this.$store.state.user && this.$store.state.user.rol == 'Engineer';
    },
    esCliente(){
      return this.$store.state.usuario && this.$store.state.usuario.rol == 'ManagerHospital';
    }
  },
  created(){
    this.$store.dispatch("autoLogin");
  },
  methods:{

  }
}
</script>
