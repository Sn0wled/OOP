#include <iostream>
#include "complex.h"

using namespace std;

int main() {
	setlocale(LC_ALL, ".1251");
	// конструктор по умолочанию
	complex a;
	cout << "a: " << a << endl; // a: Re = 0, Im = 0
	// конструктор приведения
	complex b(4);
	cout << "b: " << b << endl; // b: Re = 4, Im = 0
	// конструктор преобразования
	complex c(5.3, 10.5);
	cout << "c: " << c << endl; // c: Re = 5.3, Im = 10.5
	// конструктор копий
	complex d(c);
	cout << "d: " << d << endl; // d: Re = 5.3, Im = 10.5
	// оператор присваивания
	a = c;
	cout << "a: " << a << endl; // a: Re = 5.3, Im = 10.5

	// операция приведения к int
	int integer = int(a);
	cout << "integer = " << integer << endl; // integer = 5
	// операция приведения к double
	double doub = double(a);
	cout << "doub = " << doub << endl; // doub = 5.3
	// операция приведения к char
	char ch = char(a);
	cout << "ch = " << ch << endl; // ch = ♣

	cout << "Пусть:" << endl;
	b = { 2.3, 10.5 };
	cout << "b: " << b << endl; // b: Re = 2.3, Im = 10.5
	c = { 4.13, 1.4 };
	cout << "c: " << c << endl; // c: Re = 4.13, Im = 1.4

	// оператор сложения
	a = b + c;
	cout << "a = b + c: " << a << endl; // a = b + c: Re = 9.3, Im = 10.5
	// оператор вычитания
	a = b - c;
	cout << "a = b - c: " << a << endl; // a = b - c: Re = -1.83, Im = 9.1
	// оператор умножения
	a = b * c;
	cout << "a = b * c: " << a << endl; // a = b * c: Re = -5.201, Im = 46.585
	// оператор деления
	a = b / c;
	cout << "a = b / c: " << a << endl; // a = b / c: Re = 1.2725, Im = 2.11102

	// дружественная функциия operator+ для int
	a = integer + b;
	cout << "a = integer + b: " << a << endl; // a = integer + b: Re = 7.3, Im = 10.5
	// дружественная функциия operator- для int
	a = integer - b;
	cout << "a = integer - b: " << a << endl; // a = integer - b: Re = 2.7, Im = -10.5
	// дружественная функциия operator* для int
	a = integer * b;
	cout << "a = integer * b: " << a << endl; // a = integer * b: Re = 11.5, Im = 52.5
	// дружественная функциия operator- для int
	a = integer / b;
	cout << "a = integer / b: " << a << endl; // a = integer / b: Re = 0.0995326, Im = -0.454388
	// дружественная функциия operator% для int
	a = integer % b;
	cout << "a = integer % b: " << a << endl; // a = integer % b: Re = 5, Im = 0

	// дружественная функциия operator+ для double
	a = doub + b;
	cout << "a = doub + b: " << a << endl; // a = doub + b: Re = 7.6, Im = 10.5
	// дружественная функциия operator- для double
	a = doub - b;
	cout << "a = doub - b: " << a << endl;// a = doub - b: Re = 3, Im = -10.5
	// дружественная функциия operator* для double
	a = doub * b;
	cout << "a = doub * b: " << a << endl; // a = doub * b: Re = 12.19, Im = 55.65
	// дружественная функциия operator- для double
	a = doub / b;
	cout << "a = doub / b: " << a << endl; // a = doub / b: Re = 0.105505, Im = -0.481651
	// дружественная функциия operator% для double
	a = doub % b;
	cout << "a = doub % b: " << a << endl; // a = doub % b: Re = 5.3, Im = 0

	a = { 4, 7 };
	cout << "a: " << a << endl; // a: Re = 4, Im = 7
	// operator-
	b = -a;
	cout << "b = -a: " << b << endl; // b = -a:: Re = -4, Im = -7
	// operator-- постфиксный
	cout << "a--: " << (a--) << endl;// a--: Re = 4, Im = 7
	cout << "a: " << a << endl; // a: Re = 3, Im = 7
	// operator-- префиксный
	cout << "--a: " << --a << endl; // --a: Re = 2, Im = 7
	cout << "a: " << a << endl; // a: Re = 2, Im = 7

	// operator++ постфиксный
	cout << "a++: " << a++ << endl; // a++: Re = 2, Im = 7
	cout << "a: " << a << endl; // a: Re = 3, Im = 7
	// operator++ префиксный
	cout << "++a: " << ++a << endl; // ++a : Re = 4, Im = 7
	cout << "a: " << a << endl; // a: Re = 4, Im = 7

	cout << "Присваиваем:" << endl;
	a = { 1, 2 };
	b = { 2, 4 };
	cout << "a: " << a << endl; // a: Re = 1, Im = 2
	cout << "b: " << b << endl; // b: Re = 2, Im = 4
	cout << "a < b = " << (a < b) << endl; // a < b = 1
	cout << "a > b = " << (a > b) << endl; // a > b = 0
	cout << "a <= b = " << (a <= b) << endl; // a <= b = 1
	cout << "a >= b = " << (a >= b) << endl; // a >= b = 0
	cout << "a == b = " << (a == b) << endl; // a == b = 0
	cout << "a != b = " << (a != b) << endl; // a != b = 1

	cout << "2 < b = " << (2 < b) << endl; // 2 < b = 0
	cout << "2 > b = " << (2 > b) << endl; // 2 > b = 0
	cout << "2 <= b = " << (2 <= b) << endl; // 2 <= b = 1
	cout << "2 >= b = " << (2 >= b) << endl; // 2 >= b = 0
	cout << "2 == b = " << (2 == b) << endl; // 2 == b = 0
	cout << "2 != b = " << (2 != b) << endl; // 2 != b = 1

	cout << "2.0 < b = " << (2.0 < b) << endl; // 2.0 < b = 0
	cout << "2.0 > b = " << (2.0 > b) << endl; // 2.0 > b = 0
	cout << "2.0 <= b = " << (2.0 <= b) << endl; // 2.0 <= b = 1
	cout << "2.0 >= b = " << (2.0 >= b) << endl; // 2.0 >= b = 0
	cout << "2.0 == b = " << (2.0 == b) << endl; // 2.0 == b = 0
	cout << "2.0 != b = " << (2.0 != b) << endl; // 2.0 != b = 1
}
