/* 2018 ReVoL Primer Template */
// main.cpp
// тема: 
#include "class.h"
#include <locale.h>

int main() {
	setlocale(LC_ALL, ".1251");
	Mersedes m("123");
	cout << m.get_brand() << m.get_model();
	m.drive();
	m.turn_on();
	m.drive();
	Bicycle b("234", "567");
	b.drive();
}
