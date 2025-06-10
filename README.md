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

## 2) (2 punts) Explica de quines formes s’aplica la concurrència en les CPU’s de més d’un nucli actualment. Raona quins són els avantatges d’aplicar cada tipus.

La concurrència és la capacitat d’un sistema per gestionar múltiples tasques aparentment alhora. No significa necessàriament que s’estiguin executant exactament al mateix temps (això seria paral·lelisme), sinó que el sistema és capaç de canviar ràpidament entre tasques per donar la sensació que totes avancen alhora.

En els processadors antics, només hi havia un component encarregat d’executar les instruccions que es deia CPU. Actualment, es parla de nuclis (cores). 
Quantes més CPUs disposem, més processos alhora podrem executar.

Avui dia, la majoria de sistemes operatius aprofiten els intervals d’inactivitat dels processos —quan, per exemple, esperen una entrada de l’usuari o la finalització d’una operació d’E/S— per carregar un altre procés al processador. D’aquesta manera s’aconsegueix una aparent execució paral·lela

Els processos es poden executar de tres formes diferents:

 - Multiprogramació: Un sol processador, per tant, un sol procés en execució en moment concret del temps. Durant l'execució s'alterna amb altres tasques del mateix o altres programes. Usuari experimenta que tots els programes s'executen al mateix temps.


-  Programació paral·lela: El processador té diferents nuclis. Cada nucli executa un procés diferent al mateix temps. El SO planifica i gestiona els treballs a executar per cada nucli. Tots els processos comparteixen la mateixa memòria.


-  Programació distribuïda: diferents ordinadors en xarxa amb la seva pròpia memòria i processadors. Gestió d'ordinadors en paral·lel. Al no compartir memòria requereixen un alt rendiment de comunicació en xarxa.

## 3)  (4 punts) Pel que fa a programació paral·lela i programació asíncrona:
### a) Enumera i explica les diferències entre elles:

- Bloqueig vs no-bloqueig:
   • Paral·lel: sovint assigna cada tasca a un fil o nucli (pot bloquejar-se).
   • Asíncron: no crea fil addicional per esperar; l’operació de llarga durada no bloqueja el remetent.
- Mecanisme :
  • Paral·lel: Thread, Task.Run, divides and conquer. 
  • Asíncron: async/await, callbacks, promises, event-loop.
- Escalabilitat :
  • Paral·lel: limitat per nuclis físics i cost de context-switch. 
  • Asíncron: excel·lent per I/O massiu (milers de connexions simultànies).
- Ús de recursos 
  • Paral·lel: més memòria i CPU per cada fil.
  • Asíncron: reusa el mateix fil per a moltes operacions I/O.

### b) Explica cada pas del cicle de vida d’aquest mètode asíncron:

1) Al cridar GetUrlContentLengthAsync(), es crea l’HttpClient i s’inicia immediatament la tasca GetStringAsync, que retorna un Task<string> sense bloquejar el fil actual. El mètode continua executant el codi síncron fins a trobar l’await.
2) Es crida DoIndependentWork(), que imprimeix “Working ...” i acaba ràpidament. Tot aquest treball s’executa en el mateix fil, abans que el mètode es suspengui.
3) Quan arriba a await getStringTask, el mètode es suspèn, retorna al seu cridant un Task<int> incomplet i allibera el fil per a altres feines.
4) El mètode es reemprèn on va quedar atura quan completa la descàrrega del http: recupera contents i calcula contents.Length. Aquesta reanudació pot ocórrer en un fil del pool o en el context original, segons el seu SynchronizationContext.
5) El valor de la longitud del contingut  es retornat com a resultat final del Task<int>. El codi que va fer l’await rep aquest resultat i continua la seva execució.

### c) De la següent llista d’aplicacions digues quines faries servir únicament programació paral·lela i quina programació asíncrona. Raona la teva resposta:

- Processament de lots d’imatges: aplicació que ha de processar una quantitat X d’imatges el més eficientment possible:
  
  Paral·lel, per millorar el rendiment utilitzant la maxima capacitat de la cpu en diferents nuclis.
- Aplicació d’escriptori per a usuaris: aplicació amb una UI que ha de ser fluida.
  
  Asíncron, evitem bloquejar el fil de la UI quan llegim fitxers, xarxa mantenint la interfície reactiva.
- Aplicació de missatgeria en temps real.
  
  Asíncron, moltes connexions i petits missatges: millor model no-bloquejant per escalar a milers d’usuaris.
- Renderització de gràfics en 3d: es renderitza blocs petits de la imatge i s’ajunten en una sola.
  
  Paral·lel, l’operació és intensiva en càlcul; assignar blocs de píxels a diversos nuclis (o GPU) redueix temps de render.

## 7)  (4 punts) Analitza el següent codi, explica que pretén fer i determina si té errors o punts de millora per un ús correcte dels Threads. 
### a) Enumera i explica els erros i les millores trobades

1. Stopwatch iniciat en cada bucle, ha de iniciarse abans del for. Tampoc es para en cap moment.
2. No s’usa Thread.Join, el Main finalitza abans que els fils acabin.
3. GlobalMax/GlobalMin no són segurs (condicions de cursa). Falta sincronització (lock).
4. Mesura de temps incorrecta: sW.Restart() reinicia el temps ha de fer sW.Elapsed.
5. Validació d’entrada: pot fallar si l’usuari introdueix text no numèric.
6. Falta la llibreria System.Diagnostics.

### b) Reescriu el codi de forma correcte

using System;
using System.Threading;
using System.Diagnostics;

namespace SensorRace
{
    class Program
    {
        private static int[] Readings;
        private static int GlobalMax = int.MinValue;
        private static int GlobalMin = int.MaxValue;
        private static readonly object LockObject = new object();

        static void Main(string[] args)
        {
            int sensors;
            Console.Write("Introdueix el nombre de sensors: ");
            while (!int.TryParse(Console.ReadLine(), out sensors) || sensors <= 0)
            {
                Console.WriteLine("Entrada invàlida. Si us plau, introdueix un nombre enter positiu.");
                Console.Write("Introdueix el nombre de sensors: ");
            }

            Readings = new int[sensors];
            Thread[] threads = new Thread[sensors];

            // Iniciem el cronòmetre abans de crear els fils
            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < sensors; i++)
            {
                int id = i;
                threads[i] = new Thread(() =>
                {
                    // Cada fil utilitza el seu Random per evitar condicions de cursa
                    var localRng = new Random(Guid.NewGuid().GetHashCode());
                    for (int j = 0; j < 100000; j++)
                    {
                        int value = localRng.Next(-20, 51);
                        Readings[id] = value;

                        lock (LockObject)
                        {
                            if (value > GlobalMax) GlobalMax = value;
                            if (value < GlobalMin) GlobalMin = value;
                        }
                    }
                });

                threads[i].Start();
            }

            // Esperem que tots els fils acabin abans de continuar
            foreach (var thread in threads)
                thread.Join();

            stopwatch.Stop();

            Console.WriteLine($"Final – Max: {GlobalMax}, Min: {GlobalMin}");
            Console.WriteLine($"Temps total de procés: {stopwatch.Elapsed}");
        }
    }
}








