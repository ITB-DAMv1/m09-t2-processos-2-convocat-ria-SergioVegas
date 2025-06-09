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


