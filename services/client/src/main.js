import { createApp } from 'vue'

import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap"
import { library } from "@fortawesome/fontawesome-svg-core";
import { faPenSquare } from "@fortawesome/free-solid-svg-icons";
import { faCopy } from '@fortawesome/free-solid-svg-icons';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { faPlusCircle } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";


import App from './App.vue'

library.add(faPenSquare);
library.add(faCopy);
library.add(faTrash);
library.add(faPlusCircle);

createApp(App)
  .component("font-awesome-icon", FontAwesomeIcon)
  .mount("#app");
