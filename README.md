# GoodCalc
Библиотека для математических операций с поддержкой int, double и string.

## Возможности
- **Арифметика**: `Add`, `Substract`, `Multiply`, `Divide`
- **Степень и корень**: `Pow`, `Sqrt`
- **Новые в 1.1.0**:
  - `SuperSum` – конкатенация чисел (`SuperSum(21, 12) = 2112`)
  - `Calculator` – вычисление выражений (`"2 + 2 * 4"` → `48`)

## Примеры
```csharp
double sum = MathCalc.Add("5,5", "4,5"); // 10,0
double sqrt = MathCalc.Sqrt(25);         // 5.0
double super = MathCalc.SuperSum(3, 5);  // 35.0
double calc = MathCalc.Calculator("2 + 2,1 * 4"); // 16,4
```

## Установка
```bash
dotnet add package MathLibrary --version 1.1.0
```