# T2. 2ona Convocatòria: Recull d’activitats

## 1) (2 punts) Cerca un mínim de 5 aplicacions o tecnologies que fan servir programació distribuïda. Explica que fan i per què necessiten ser distribuïdes.

### Apache Hadoop
- Què fa? Framework de processament massiu de dades que inclou HDFS (sistema de fitxers distribuït) i MapReduce (execució en paral·lel).
  
- Per què distribuït? Per tractar petabytes de dades repartint-les en centenars de nodes i garantir tolerància a falles mitjançant rèpliques.
  
### Apache Spark
- Què fa? Motor de càlcul en memòria per a processament per lots, streaming, ML i SQL.
- Per què distribuït? Per accelerar tasques que sobrepassen la capacitat d’un sol servidor i suportar conjunts de dades i càrregues de treball en temps real.
  
### Kubernetes

- Què fa? Orquestrador de contenidors (Docker, cri-o…) que deploya, escala i recupera serveis automàticament.
- Per què distribuït? Permet rèpliques de microserveis en múltiples nodes per alta disponibilitat, equilibri de càrrega i autorecuperació de fallades.

### Blockchain (p. ex. Bitcoin, Ethereum)

- Què fa? Llibre de registre immutable on cada transacció és validada per tots els nodes de la xarxa.
- Per què distribuït? No hi ha punt central de confiança; la seguretat i la resistència a manipulacions s’aconsegueixen perquè cada node manté còpia completa i aplica consens.

### BitTorrent

- Què fa? Protocol peer-to-peer per compartir fitxers fragmentats en trossos; cada client esdevé servidor d’altres clients.
- Per què distribuït? Evita colls d’ampolla en un servidor central i aprofita la suma d’ample de banda dels iguals per augmentar la velocitat i la robustesa.

### Apache Kafka

- Què fa? Plataforma de missatgeria distribuïda per a fluxos d’esdeveniments en temps real amb persistència i rèpliques.
- Per què distribuït? Escala a milions d’esdeveniments per segon i elimina punt únic de fallada, repartint particions i rèpliques en un clúster.

## 1) (2 punts) Explica de quines formes s’aplica la concurrència en les CPU’s de més d’un nucli actualment. Raona quins són els avantatges d’aplicar cada tipus.

La concurrència és la capacitat d’un sistema per gestionar múltiples tasques aparentment alhora. No significa necessàriament que s’estiguin executant exactament al mateix temps (això seria paral·lelisme), sinó que el sistema és capaç de canviar ràpidament entre tasques per donar la sensació que totes avancen alhora.

En els processadors antics, només hi havia un component encarregat d’executar les instruccions que es deia CPU. Actualment, es parla de nuclis (cores). 
Quantes més CPUs disposem, més processos alhora podrem executar.

Avui dia, la majoria de sistemes operatius aprofiten els intervals d’inactivitat dels processos —quan, per exemple, esperen una entrada de l’usuari o la finalització d’una operació d’E/S— per carregar un altre procés al processador. D’aquesta manera s’aconsegueix una aparent execució paral·lela

Els processos es poden executar de tres formes diferents:

 - Multiprogramació: Un sol processador, per tant, un sol procés en execució en moment concret del temps. Durant l'execució s'alterna amb altres tasques del mateix o altres programes. Usuari experimenta que tots els programes s'executen al mateix temps.


-  Programació paral·lela: El processador té diferents nuclis. Cada nucli executa un procés diferent al mateix temps. El SO planifica i gestiona els treballs a executar per cada nucli. Tots els processos comparteixen la mateixa memòria.


-  Programació distribuïda: diferents ordinadors en xarxa amb la seva pròpia memòria i processadors. Gestió d'ordinadors en paral·lel. Al no compartir memòria requereixen un alt rendiment de comunicació en xarxa.

