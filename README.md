# Lilo_Et_Stitch_SERVEUR
<p align="center">
  <img src="https://github.com/dept-info-iut-dijon/Lilo-et-Stitch/assets/134507319/7ff7b15c-7baf-4c2b-8244-a34d3b6b4758" alt="Logo" width="40%">
</p>


## Fonctionnalités

- [x] sauvegarde du projet terminé
- [x] ouverture d’un patron
- [ ] signaler un projet (en bonus)
- [ ] modérer les projets (en bonus)

**Lien vers le client :** https://github.com/dept-info-iut-dijon/Lilo-et-Stitch

## Fonctionnement

L'API suit un modèle classique MVC (Modèle-Vue-Contrôleur) où les contrôleurs GetDataController et SendDataController servent de points d'entrée pour les opérations de récupération et d'envoi des données, respectivement.
<p align="center">
  <img src="https://github.com/dept-info-iut-dijon/Lilo_Et_Stitch_SERVEUR/assets/134505521/39f06876-e2d8-4b89-8b78-cd1c13385266" alt="Diagramme de classe de l'API" width="100%">
</p>

## Contrôleurs

### GetDataController

- `GetImages(int? page)`
  - Retourne une liste d'images sous forme de JSON en utilisant le numéro de page donné. 
  - Si `page` est nul, retourne une erreur `BadRequest`.

- `GetSettings(int? Id)`
  - Retourne les paramètres sous forme de JSON correspondant à l'identifiant `Id`. 
  - Si `Id` est nul, retourne une erreur `BadRequest`.

- `GetPDF(string? name)`
  - Retourne le PDF sous forme de tableau de bytes en JSON correspondant au nom du projet donné. 
  - Si `name` est nul, retourne une erreur `BadRequest`.

- `GetImgBySearch(string? name, int page)`
  - Retourne une liste de 6 images correspondant au nom recherché en JSON. 
  - Si `name` est nul, effectue la recherche avec une chaîne vide.

- `GetNumberPage(string? word)`
  - Retourne le nombre de pages pour une recherche donnée en JSON. 
  - Si `word` est nul, effectue la recherche avec une chaîne vide.

### SendDataController

- `ReceiveParameters(string? name, int? step, int? maxColors, string? gridColor)`
  - Reçoit les paramètres et les enregistre. 
  - Tous les paramètres doivent être non nuls, sinon retourne une erreur `BadRequest`.

- `AddPDF(byte[] PDF, string name)`
  - Ajoute un PDF au répertoire indiqué par `name`. 
  - Retourne un succès si `PDF` n'est pas nul, sinon une erreur `BadRequest`.

- `AddCSV(byte[] CSV, string name)`
  - Ajoute un fichier CSV au répertoire indiqué par `name`. 
  - Retourne un succès si `CSV` n'est pas nul, sinon une erreur `BadRequest`.

- `AddIMG(byte[] IMG, string name)`
  - Ajoute une image au répertoire indiqué par `name`. 
  - Retourne un succès si `IMG` n'est pas nul, sinon une erreur `BadRequest`.

- `CheckIfExist(string name)`
  - Vérifie si le motif indiqué par `name` existe déjà. 
  - Retourne un message de succès si le motif n'existe pas, sinon un `BadRequest`.

- `clearOnePatterns(string name)`
  - Supprime le motif spécifié par `name`. 
  - Retourne un succès si la suppression est réussie, sinon une erreur `BadRequest`.

- `clearAll()`
  - Supprime tous les motifs enregistrés. 
  - Retourne toujours un succès.

Chaque méthode est documentée avec les paramètres attendus et le type de réponse retournée. Pour les méthodes qui acceptent des paramètres optionnels (`nullables`), une valeur par défaut est utilisée si aucun paramètre n'est fourni.

<p>Vous trouverez plus d'informations dans le guide de maintenance se trouvant dans la release souhaitée.</p>
<br>

*Ce projet a été réalisé dans un cadre pédagogique. A ce titre, il n'a pas vocation à être utilisé en dehors de ce cadre. Les différents éléments utilisés dans ce projet appartiennent à leurs propriétaires respectifs.*
