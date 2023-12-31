/* 2018 ReVoL Primer Template */
// main.cpp
// тема: 
#include "class.h"

int open(LPCSTR path, FILE** file) {
	*file = fopen(path, "rt");
	if (*file) return 1;
	if (errno == ENOENT) {
		cout << "No such file or directory.\n";
	}
	else if (errno == EACCES) {
		cout << "Access denied.\n";
	}
	else if (errno == EINVAL) {
		cout << "Empty or wrong path.\n";
	}
	return 0;
}

void openc(LPCSTR path, FILE** file) {
	*file = fopen(path, "rt");
	cout << errno << endl;
	if (errno) {
		throw errno;
	}
}

void opencl(LPCSTR path, FILE** file) {
	*file = fopen(path, "rt");
	cout << errno << endl;
	switch (errno)
	{
	case ENOENT:
		throw fe_no_path();
		break;
	case EACCES:
		throw fe_access_denied();
		break;
	case EINVAL:
		throw fe_invalid_arg();
		break;
	}
}

int main() {
    /*int x = 0;
    short z = 5;
	try
	{
		int y = 0;
		x = x / y;
	}
	catch (int x) {
		cout << "int thrown " << x << endl;
	}
	catch (double x) {
		cout << "double thrown " << x << endl;
	}
	catch (char x) {
		cout << "char thrown " << x << endl;
	}
	catch (const char * x) {
		cout << "char* thrown " << x << endl;
	}
	catch (...) {
		cout << "... thrown " << endl;
	}*/


	/*FILE* file = 0;
	int result = open("", &file);
	if (!result) return 0;
	cout << "success.\n";
    return 0;*/

	/*FILE* file = 0;
	try {
		opencl("", &file);
	}
	catch (file_error fe) {
		cout << fe.message() << endl;
		return 0;
	}
	cout << "Success\n";*/

	/*try {
		throw new file_open_err();
	}
	catch (array_err * e) {
		printf("catch 1: %s\n", typeid(*e).name());
	}
	catch (file_err* e) {
		printf("catch 2: %s\n", typeid(*e).name());
	}
	catch (gen_err* e) {
		printf("catch 3: %s\n", typeid(*e).name());
	}
	catch (...) {
		printf("catch all: Exception\n");
	}*/

	try {
		m_class a("a", "b");
	}
	catch (int) {
		cout << "exception.\n";
		return 0;
	}
	cout << "Success\n";
}
