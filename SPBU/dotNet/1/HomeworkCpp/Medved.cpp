#include "stdafx.h"
#include "Medved.h"

using namespace System;

void Medved::MeetMedved()
{
	Console::WriteLine(HomeworkCs::Medved::greet + "C++");
	HomeworkFs::Medved::MeetMedved();
}
