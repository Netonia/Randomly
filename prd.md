# PRD - Random Data Generator Blazor Wasm

## Objectif
Créer une application Blazor WebAssembly qui génère des données aléatoires selon une liste de champs définis par l'utilisateur, avec support de templates Liquid pour personnaliser la sortie.

## Public cible
Développeurs, testeurs QA, data engineers, et toute personne ayant besoin de jeux de données fictifs pour tests ou prototypes.

## Fonctionnalités principales

### 1. Définition des champs
- L'utilisateur peut ajouter/supprimer/modifier des champs.
- Chaque champ doit avoir un **nom** et un **type de données**.
- Types de données possibles : `firstName`, `lastName`, `email`, `phoneNumber`, `city`, `country`, `integer`, `decimal`, `boolean`, `date`, etc.
- Interface utilisateur pour gérer la liste de champs (CRUD).

### 2. Génération de données
- L'utilisateur définit le **nombre de lignes** à générer.
- Les données sont générées aléatoirement selon le type de chaque champ.
- Génération directe dans un tableau affiché dans l'app.

### 3. Liquid Template
- L'utilisateur peut personnaliser la sortie des données via un **template Liquid**.
- Exemple de template : `{{ firstName }} {{ lastName }} - {{ city }}, {{ country }}`
- La librairie **Fluid.Core** est utilisée pour parser et rendre le template.
- Support d’itération sur plusieurs lignes via `{% for item in items %} ... {% endfor %}`.

### 4. Editeur Liquid intégré
- Utilisation de **Monaco Editor** via BlazorMonaco.
- Syntax highlighting, autocomplete, et indentation.
- Sauvegarde automatique du template localement.

### 5. Export / Copie
- L'utilisateur peut **copier** le résultat généré dans le presse-papier.
- Export possible en **CSV**, **JSON**, ou **Texte brut**.

### 6. Prévisualisation et feedback
- Affichage dynamique de la sortie du template en temps réel.
- Gestion des erreurs de template ou de génération avec messages clairs.

## Architecture technique
- **Blazor WebAssembly** .NET 9.0 pour l’interface front-end.
- **Fluid.Core** pour parsing et rendu Liquid.
- **BlazorMonaco** pour l’éditeur de template.
- **Random Data Service** : service interne pour générer des données aléatoires selon type. Utilisr Bogus.Faker
- Stockage local facultatif des templates via **localStorage**.

## UI/UX
- Layout simple avec 2 panneaux :
  1. Liste de champs et paramètres de génération.
  2. Editeur Liquid + prévisualisation du résultat.
- Boutons : `Ajouter champ`, `Générer`, `Copier`, `Exporter`.
- Indicateur de chargement si génération volumineuse.

## Contraintes
- App 100% client-side (WASM) pour éviter besoin de serveur.
- Compatible avec les navigateurs modernes.
- Limite configurable pour le nombre de lignes générées pour éviter freeze.

## Extensions possibles
- Génération conditionnelle (ex : si country == 'France', city = ...)
- Partage de templates via URL ou JSON.
- Intégration d’autres types de données (ex : UUID, adresse complète, lorem ipsum).
- Mode multi-lignes dans preview avec pagination pour gros volumes.