# ---------------------------------------------
# Clean project

# SPDX-FileCopyrightText: (c) 2022-2023 T. Graf
# SPDX-License-Identifier: Apache-2.0
# ---------------------------------------------

dotnet clean
Remove-Item "Tethys.Dgml\bin" -Recurse
Remove-Item "Tethys.Dgml\obj" -Recurse