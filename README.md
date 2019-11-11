# Masterclass TDD

## Exercice

Kata [FooBarQix](http://codingdojo.org/kata/FooBarQix/), variante du _FizzBuzz_ dont l’algorithme à produire s’avère pas si trivial que cela, d’autant plus en _"Step 2"_. Le challenge est d’autant plus grand de trouver un bon design.

## Solution (en C♯)

> Cf. dossier `./csharp`.

- L’idée générale est d’avoir un ensemble de "règles" dont on vérifie la satisfaction pour le nombre en entrée.
- SUT : classe statique `FooBarQix` qui contient les règles, appelées `Match` et qui contiennent la condition à satisfaire via leur propre méthode `bool Test(int number)` et le mot correspondant `Word` (`"Foo"`, `"Bar"`...).
- Tests préliminaires, portant sur la méthode `FooBarQix.Test(int number)` qui renvoie les règles qui sont satisfaites pour le nombre spécifié.
  - Cela permet de tester les règles indépendamment les unes des autres et indépendamment de leur `Word`.
  - Afin d’avoir des règles équilibrées entre celles du type `MultipleOf` (celles du *FizzBuzz*) et les autres du type `DigitAt`, l’astuce consiste à dupliquer les règles `DigitAt` pour tous les index possibles dans le nombre en entrée (i.e. la longueur du nombre converti en chaîne). On peut alors vérifier qu’on a bien un *"Digit 3 at 0"* dans le nombre "30" et un *"Digit 3 at 1"* dans le nombre "23".

```cs
private static IEnumerable<Match> Matches(int length)
{
    yield return new MultipleOfMatch("Foo", 3);
    yield return new MultipleOfMatch("Bar", 5);
    yield return new MultipleOfMatch("Qix", 7);

    for (var i = 0; i < length; i++) // ☝️ To test each position
    {
        yield return new DigitAtMatch("Foo", 3, i);
        yield return new DigitAtMatch("Bar", 5, i);
        yield return new DigitAtMatch("Qix", 7, i);
        yield return new DigitAtMatch("*",   0, i); // ☝️ Step 2
    }
}
```

- Tests complets, portant sur la méthode `string FooBarQix.Of(int number)` qui renvoie la chaîne définie dans les specs.
  - Cette méthode ne fait qu’appeler `Test()`, puis de mapper les `Match`es vers leur `Word` et enfin de gérer les cas aux limites.
  - Cas 1 : aucune règle trouvée => renvoyer le nombre converti en chaîne, en remplaçant les "0" par des "*" à la _step 2_.
  - Cas 2 : en _step 2_, si on n’obtient que des matches du type `Digit 0`, on les ignore pour rebasculer sur le cas 1. Cela permet d’avoir `"1*1"` pour `101` plutôt que juste `"*"`.

```cs
public static string Of(int number) =>
    Test(number)
        .EmptyIfOnlyDigit0() // ☝️ Cas 2
        .Select(x => x.Word)
        .DefaultIfEmpty($"{number}".Replace("0", "*")) // ☝️ Cas 1
        .JoinToString();
```
